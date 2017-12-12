using UnityEngine;
using System.Collections;

public class LevelCreator : MonoBehaviour
{
    public static int currentLevel = 0;
	private int size;
	public static int LevelSize;
	public float margin;
	public GameObject wormPrefab;
	public GameObject[,] worms;
	public int[,] effectedCount;
    public int detailCount;
    public GameObject[] detailObjects;
    public AudioClip upSfx, downSfx;
    public Level[] Levels = new Level[20];
	void Awake()
	{
        Worm[,] level0map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, false) },
                                           {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false) },
                                            {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, false) }};

        Worm[,] level1map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) },
                                           {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false) },
                                            {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) }};

        Worm[,] level2map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, true) },
                                           {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, true) },
                                            {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) }};

        Worm[,] level3map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, true) },
                                           {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) },
                                            {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, false) }};

        Worm[,] level4map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) },
                                           {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, true) },
                                            {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) }};

        Worm[,] level5map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false) },
                                           {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, true) },
                                            {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, true) }};

        Worm[,] level6map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false) },
                                           {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false) },
                                            {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, false) }};

        Worm[,] level7map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, false) },
                                           {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) },
                                            {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) }};

        Worm[,] level8map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) },
                                           {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) },
                                            {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, true) }};

        Worm[,] level9map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false) },
                                           {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, false) },
                                            {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) }};

        Worm[,] level10map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) , new Worm((int)Worm.WormType.RED, true)},
                                           {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) },
                                            {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) , new Worm((int)Worm.WormType.RED, true)},
                                             {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, true) , new Worm((int)Worm.WormType.RED, true)}};

        Worm[,] level11map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false) , new Worm((int)Worm.WormType.RED, false)},
                                           {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) },
                                            {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) , new Worm((int)Worm.WormType.RED, true)},
                                             {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, true) , new Worm((int)Worm.WormType.RED, true)}};

        Worm[,] level12map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) , new Worm((int)Worm.WormType.RED, false)},
                                           {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, false) },
                                            {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) , new Worm((int)Worm.WormType.RED, false)},
                                             {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) , new Worm((int)Worm.WormType.RED, true)}};

        Worm[,] level13map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false) , new Worm((int)Worm.WormType.RED, true)},
                                           {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false) },
                                            {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, false) , new Worm((int)Worm.WormType.RED, true)},
                                             {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) , new Worm((int)Worm.WormType.RED, true)}};

        Worm[,] level14map = new Worm[,]{ {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, true) , new Worm((int)Worm.WormType.RED, true)},
                                           {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, true) },
                                            {new Worm((int)Worm.WormType.RED,true),new Worm((int)Worm.WormType.RED, true), new Worm((int)Worm.WormType.RED, true) , new Worm((int)Worm.WormType.RED, true)},
                                             {new Worm((int)Worm.WormType.RED,false),new Worm((int)Worm.WormType.RED, false), new Worm((int)Worm.WormType.RED, false) , new Worm((int)Worm.WormType.RED, true)}};

        Levels[0] = new Level(4, 1, level0map);
        Levels[1] = new Level(4, 1, level1map);
        Levels[2] = new Level(4, 1, level2map);
        Levels[3] = new Level(8, 2, level3map);
        Levels[4] = new Level(8, 2, level4map);
        Levels[5] = new Level(8, 2, level5map);
        Levels[6] = new Level(8, 2, level6map);
        Levels[7] = new Level(8, 2, level7map);
        Levels[8] = new Level(8, 2, level8map);
        Levels[9] = new Level(8, 2, level9map);
        Levels[10] = new Level(8, 2, level10map);
        Levels[11] = new Level(8, 2, level11map);
        Levels[12] = new Level(25, 3, level12map);
        Levels[13] = new Level(20, 3, level13map);
        Levels[14] = new Level(15, 3, level14map);
        Levels[15] = new Level(3, 1, level1map);
        Levels[16] = new Level(3, 1, level1map);
        Levels[17] = new Level(3, 1, level1map);
        Levels[18] = new Level(3, 1, level1map);
        Levels[19] = new Level(3, 1, level1map);

        size = Levels[currentLevel].levelMap.GetLength(0);
		LevelCreator.LevelSize = size;
	}
	void Start ()
	{
        for (int i = 0; i < detailCount; i++)
        {
            Instantiate(detailObjects[Random.RandomRange(0, detailObjects.Length)], new Vector3(Camera.main.gameObject.transform.position.x+Random.RandomRange(-2.5f,2.5f), Camera.main.gameObject.transform.position.y + Random.RandomRange(-5.0f, 0), 1), Quaternion.identity);
        }
		worms = new GameObject[size,size];
		effectedCount = new int[size,size];
		for(int i = 0; i<size;i++)
		{
			for(int j = 0; j<size; j++)
			{
				worms[i, j] = Instantiate(wormPrefab,new Vector3(i*margin,j*margin,0),Quaternion.identity) as GameObject;
                worms[i, j].AddComponent<AudioSource>();
                worms[i, j].GetComponent<WormControl>().upSfx = upSfx;
                worms[i, j].GetComponent<WormControl>().downSfx = downSfx;
                if (Levels[currentLevel].levelMap[i, j].isSelected)
                {
                    worms[i, j].GetComponent<WormControl>().isSelected = true;
                    worms[i, j].GetComponent<Animator>().Play("up");
                }
				int k = 0;
				if(i>0)
				{
					k++;
				}
				if(j>0)
				{
					k++;
				}
				if(i<size-1)
				{
					k++;
				}
				if(j<size-1)
				{
					k++;
				}
				effectedCount[i,j]=k;
			}
		}

		for(int i = 0; i<size;i++)
		{
			for(int j = 0; j<size; j++)
			{
				worms[i,j].GetComponent<WormControl>().effectedObjects = new GameObject[effectedCount[i,j]];
				int k = 0;
				if(i>0)
				{
					worms[i,j].GetComponent<WormControl>().effectedObjects[k]=worms[i-1,j];
					k++;
				}
				if(j>0)
				{
					worms[i,j].GetComponent<WormControl>().effectedObjects[k]=worms[i,j-1];
					k++;
				}
				if(i<size-1)
				{
					worms[i,j].GetComponent<WormControl>().effectedObjects[k]=worms[i+1,j];
					k++;
				}
				if(j<size-1)
				{
					worms[i,j].GetComponent<WormControl>().effectedObjects[k]=worms[i,j+1];
					k++;
				}
			}
		}

		if(size%2==0)
		{
			float posX = (worms[size/2,size/2].transform.position.x+worms[(size/2)-1,(size/2)-1].transform.position.x)/2;
			float posY = (worms[size/2,size/2].transform.position.y+worms[(size/2)-1,(size/2)-1].transform.position.y)/2;
			Camera.main.transform.position = new Vector3(posX, posY, Camera.main.transform.position.z);
		}
		else
		{
			Camera.main.transform.position = new Vector3(worms[(size-1)/2,(size-1)/2].transform.position.x,worms[(size-1)/2,(size-1)/2].transform.position.y,Camera.main.transform.position.z);
		}
	}
	void Update()
	{
		bool controlWin = true;
		for(int i = 0; i<size;i++)
		{
			for(int j = 0; j<size; j++)
			{
                if (!worms[i,j].GetComponent<WormControl>().isSelected)
                {
                    controlWin = false;
                    break;
                }
			}
			if(!controlWin)
			{
				break;
			}
		}
            if (controlWin)
            {
                GameLogic.Win();
            }
	}
}
