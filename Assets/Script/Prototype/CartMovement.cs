using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
    [Header("Variabel titik-titik jalur kereta")]
    [Tooltip("Masukkan titik-titik roadPoints dari Hierarchy ke sini secara berurutan.")]
    [SerializeField] private List<RoadPoints> roadPoints; // [Declaration]
    public List<CheckPoints> checkPoints;

    [Header("variabel nilai Kecepatan kereta")]
    public float maxSpeed = 1f; // [Declaration]
    public float acceleration = 0.5f; // [Declaration]
    public float deceleration = 0.25f; // [Declaration]
    public float breakingDisctance = 1.5f; // [Declaration]

    // Variabel nilai lainya
    private float distanceToMoveNextPoint = 0.1f; // [Declaration]
    private SpriteRenderer cartSprite; // [Declaration]
    private int currentWayPointIndex = 0; // [Declaration] currentWayPointIndex adalah indeks waypoint yang digunakan sebagai titik awal serta titik waypoint selanjutnya.
    private float currentSpeed = 0f;
    private bool isFinished = false;

    private void Start()
    {
        StartCoroutine(MoveCart());
    }
    private IEnumerator MoveCart()
    {
        // 1.   Jalankan fungsi kereta berjalan, jika terdapat titik-titik arah kereta.
        //      Tentukan titik-titik tujuan kereta berjalan. 
        if (roadPoints == null || roadPoints.Count == 0) yield return null; // [Decision]
        if (cartSprite == null) cartSprite = GetComponentInChildren<SpriteRenderer>();
        while (!isFinished)
        {
            RoadPoints targetRoadPoint = roadPoints[currentWayPointIndex]; // [Declaration]
            while (Vector3.Distance(transform.position, targetRoadPoint.transform.position) > distanceToMoveNextPoint)
            {
                // 2.   Kecepatan maksimal kereta ditentukan panjang jarak posisi titik tujuan dengan posisi kereta sekarang,
                //      jika panjang jarak tersebut lebih kecil dari nilai variabel breakingDistance (jarak kereta dengan titik tujuan sebelum mulai mengerem),
                //      maka kecepatan maksimal kereta melaju akan dikurangi,
                //      semakin kecil jarak kereta dengan titik tujuan, maka semakin kecil kecepatan maksimal kereta melaju.
                float distanceToTarget = Vector3.Distance(transform.position, targetRoadPoint.transform.position); // [Declaration]
                float targetSpeed = maxSpeed; // [Declaration]
                if (distanceToTarget < breakingDisctance)
                {
                    float speedReductionFactor = distanceToTarget / breakingDisctance; // [Declaration]
                    targetSpeed = maxSpeed * speedReductionFactor; // [Re-Declaration]
                }
                // 3.   Kereta bergerak dengan kecepatan saat ini secara akselerasi atau mulai dari lambat hingga cepat yaitu kecepatan maksimal,
                //      Jika kecepatan maksimal kereta yang ditentukan lebih besar dari kecepatan saat ini, maka kecepatan kereta saat ini dinaikkan secepat nilai variabel acceleration (nilai penambahan kecepatan kereta) hingga kecepatan maksimal kereta,
                //      Jika kecepatan maksimal kereta yang ditentukan lebih kecil dari kecepatan saat ini, maka kecepatan kereta saat ini diturunkan secepat nilai variabel deceleration (nilai pengurangan kecepatan kereta) hingga kecepatan maksimal kereta.
                if (targetSpeed > currentSpeed)
                {
                    currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
                }
                else
                {
                    currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, deceleration * Time.deltaTime);
                }
                // 4.   Pindahkan posisi kereta menuju posisi titik tujuan dengan kecepatan saat ini.
                transform.position = Vector3.MoveTowards(transform.position, targetRoadPoint.transform.position, currentSpeed * Time.deltaTime); // [Action]
                yield return null;
            }
            // 5.   Jika jarak posisi kereta dengan posisi titik tujuan lebih kecil dari 0.1f (distanceToMoveNextPoint), maka pindahkan titik tujuan ke titik berikutnya, tetapi Jika titik tujuan selanjutnya, berindex lebih besar sama dengan jumlah titik-titik arah kereta, maka variabel isFinished bernilai true, yang menandakan kereta telah sampai pada titik tujuan akhir.
            //      Jika titik tujuan selanjutnya, bernilai true pada variabel flipX, maka balik arah gambar kereta pada sumbu X.
            if (Vector3.Distance(transform.position, targetRoadPoint.transform.position) < distanceToMoveNextPoint)
            {
                cartSprite.flipX = roadPoints[currentWayPointIndex].flipX;
                if (currentWayPointIndex + 1 >= roadPoints.Count)
                {
                    isFinished = true;
                }
                else
                {
                    currentWayPointIndex++;
                }
            }
        }
    }
}