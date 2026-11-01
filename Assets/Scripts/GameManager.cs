using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private int coinSpawnAmount = 5;

    [SerializeField] private Color coinColor_1;
    [SerializeField] private Color coinColor_2;
    [SerializeField] private Color coinColor_3;

    [SerializeField] private int coinValue_1;
    [SerializeField] private int coinValue_2;
    [SerializeField] private int coinValue_3;

    [SerializeField] private float xRange = 9f;
    [SerializeField] private float yRange = 5f;

    void Start()
    {
        GenerateCoins();
    }

    public void GenerateCoins()
    {
        for (int i = 0; i < coinSpawnAmount; i++)
        {
            int coinType = Random.Range(0, 3);
            Vector2 location = new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));

            Color selectedColor = Color.white;
            int selectedValue = 0;

            switch (coinType)
            {
                case 0:
                    selectedColor = coinColor_1;
                    selectedValue = coinValue_1;
                    break;
                case 1:
                    selectedColor = coinColor_2;
                    selectedValue = coinValue_2;
                    break;
                case 2:
                    selectedColor = coinColor_3;
                    selectedValue = coinValue_3;
                    break;
            }

            GameObject newCoin = Instantiate(coinPrefab, location, Quaternion.identity);
            newCoin.GetComponent<SpriteRenderer>().color = selectedColor;
            newCoin.GetComponent<Coin>().setValue(selectedValue);
        }
    }
}
