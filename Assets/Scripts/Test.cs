using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = "C:/RUS1.txt";
        string path1 = "C:/test1.txt";

        // асинхронное чтение
        using (StreamReader reader = new StreamReader(path))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                using (StreamWriter writer = new StreamWriter(path1, true, System.Text.Encoding.UTF8))
                {
                    if (line.Length == 5)
                    {
                        writer.WriteLineAsync(line);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
