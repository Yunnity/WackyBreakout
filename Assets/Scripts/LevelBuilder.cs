using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject prefabPaddle;
    [SerializeField]
    GameObject standardBlock;
    [SerializeField]
    GameObject bonusBlock;
    [SerializeField]
    GameObject pickUpBlock;

    float blockWidth;
    float blockHeight;
    public static GameObject newPaddle;
    static int blockCount;

    // Start is called before the first frame update
    void Start()
    {
        blockCount = 0;
        Vector3 location = new Vector3(0, -4.5f, -Camera.main.transform.position.z);
        newPaddle = Instantiate(prefabPaddle, location, Quaternion.identity);

        GameObject tempBlock = Instantiate(standardBlock, location, Quaternion.identity);
        BoxCollider2D rgb2d = tempBlock.GetComponent<BoxCollider2D>();
        blockWidth = rgb2d.size.x;
        blockHeight = rgb2d.size.y;
        Destroy(tempBlock);

        int numBlocks = (int)(ScreenUtils.ScreenRight * 2 / blockWidth);
        float offset = ((ScreenUtils.ScreenRight * 2) - (blockWidth * numBlocks)) / 2;

        for(int i = 0; i < 3; i++)
        {
            Vector3 spawnLocation = new Vector3(ScreenUtils.ScreenLeft + offset + (blockWidth / 2), 
                ScreenUtils.ScreenTop - (blockHeight / 2) - (blockHeight * i),
                -Camera.main.transform.position.z);
            for(int k = 0; k < numBlocks; k++)
            {
                PlaceABlock(spawnLocation);
                spawnLocation.x += blockWidth;
            }
        }
        HUD.score = 0;
        EventManager.AddBlockDestroyedListener(BlockDestroyed);
    }

    void PlaceABlock(Vector3 blockLocation)
    {
        int spawnNum = (int)Random.Range(1, 101);
        if (spawnNum <= ConfigurationUtils.StandardProb)
        {
            GameObject normalBlock = Instantiate(standardBlock, blockLocation, Quaternion.identity);
        }
        else if (spawnNum > ConfigurationUtils.StandardProb && spawnNum < (ConfigurationUtils.StandardProb + ConfigurationUtils.BonusProb))
        {
            GameObject extraBlock = Instantiate(bonusBlock, blockLocation, Quaternion.identity);
        }
        else
        {
            GameObject newBlock = Instantiate(pickUpBlock, blockLocation, Quaternion.identity);
            int spriteNum = (int)(Random.Range(0, 2));
            if (spriteNum == 0)
            {
                newBlock.GetComponent<PickUpBlock>().BlockType = PickupEffect.Freezer;
            }
            else
            {
                newBlock.GetComponent<PickUpBlock>().BlockType = PickupEffect.Speedup;
            }
        }
        blockCount++;
    }
    public static void BlockDestroyed()
    {
        blockCount--;
        if(blockCount <= 0)
        {
            MenuManager.GoToMenu(MenuName.GameGood);
        }
    }
}
