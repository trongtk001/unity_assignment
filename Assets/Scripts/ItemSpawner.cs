using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float spawnInterval = 1f;
    public const float SpawnSpeed = 200f;
    public int maxItemCount = 3;

    private float _nextSpawnTime;
    private int _itemCount;
    private float _xConstraint = 9.2f, _yConstraint = 4.1f;

    private void Start()
    {
        _itemCount = 0;
    }

    private void Update()
    {
        if (Time.time >= _nextSpawnTime && _itemCount < maxItemCount)
        {
            SpawnItem();
            _nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnItem()
    {

        // Xác định vị trí ban đầu và hướng di chuyển ngẫu nhiên
        Vector3 spawnPosition = CalculateSpawnPosition();
        Vector3 moveDirection = CalculateMoveDirection(spawnPosition);

        // Tạo mới Prefab vật phẩm
        GameObject newItem = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        _itemCount++;

        // Di chuyển vật phẩm vào trong màn hình
        Rigidbody2D itemRb = newItem.GetComponent<Rigidbody2D>();
        itemRb.AddForce(moveDirection * SpawnSpeed);
    }
    
    public void DestroyItem(GameObject item)
    {
        Destroy(item);
        _itemCount--;
    }

    private Vector3 CalculateSpawnPosition()
    {

        // Chọn một vị trí ngẫu nhiên trên cạnh của màn hình
        float randomSide = Random.Range(0, 4); // Lựa chọn ngẫu nhiên từ 0 đến 3 để đại diện cho 4 phía

        float spawnX = 0f;
        float spawnY = 0f;

        switch (randomSide)
        {
            case 0: // Phía trên
                spawnX = Random.Range(-_xConstraint, _xConstraint);
                spawnY = _yConstraint;
                break;
            case 1: // Phía dưới
                spawnX = Random.Range(-_xConstraint, _xConstraint);
                spawnY = -_yConstraint;
                break;
            case 2: // Phía trái
                spawnX = -_xConstraint;
                spawnY = Random.Range(-_yConstraint, _yConstraint);
                break;
            case 3: // Phía phải
                spawnX = _xConstraint;
                spawnY = Random.Range(-_yConstraint, _yConstraint);
                break;
        }

        // Chuyển đổi vị trí xuất hiện thành vị trí trong không gian thế giới
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        return spawnPosition;
    }

    private Vector3 CalculateMoveDirection(Vector3 spawnPosition)
    {
        // Xác định hướng di chuyển ngẫu nhiên dựa trên vị trí ban đầu của vật phẩm
        Vector3 moveDirection = transform.position - spawnPosition;
        moveDirection.Normalize();

        return moveDirection;
    }
}

