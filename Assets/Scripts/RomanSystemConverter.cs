using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RomanSystemConverter : MonoBehaviour
{
    public Text btn;
    public int input_numbers;
    public string output_numbers ;
    public string[] roman_numbers;
    public int[] arabic_numbers;

    public string ConvertToRomans(string input_arabic_numbers)
    {
        output_numbers = "";
        input_numbers =int.Parse(input_arabic_numbers);
        if (input_numbers == 0)
        {
            output_numbers = "N";
        }
        for (int i=0;i<roman_numbers.Length;i++)
        {
            if (input_numbers>=arabic_numbers[i])
            {
                while (input_numbers >= arabic_numbers[i])
                {
                    output_numbers += roman_numbers[i];
                    input_numbers -= arabic_numbers[i];
                }
            }
        }
        return (output_numbers);
    }
}
