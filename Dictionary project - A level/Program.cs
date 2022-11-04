using System;
using System.Collections.Generic;

namespace Dictionary_project___A_level
{
	static class HousePeopleManage
	{
		static Dictionary<string, int> HouseAddressPeopleNumberDic = new Dictionary<string, int>();

		public static void AddEntry(string key, int value)
		{
			HouseAddressPeopleNumberDic.Add(key, value);
		}

		public static void OverwriteEntry(string key, int value)
		{
			HouseAddressPeopleNumberDic[key] = value;
		}

		public static int GetEntry(string key)
		{
			return HouseAddressPeopleNumberDic[key];
		}

		public static bool CheckEntry(string key)
		{
			return HouseAddressPeopleNumberDic.ContainsKey(key);
		}

		public static string IterateDictionary()
		{
			string output = "";
			foreach(KeyValuePair<string, int> entry in HouseAddressPeopleNumberDic)
			{
				output += $"address: {{{entry.Key}}} | amount of people: {{{entry.Value}}}\n";
			}
			return output;
		}
	}

	internal class Program
	{

		static void Main(string[] args)
		{
			while (true)
			{
				Console.Write("What would you like to do\na) add or overwrite entry\ng) get entry\ni) iterate entries\n>>>");
				char inputOperation = char.ToLower(Console.ReadKey().KeyChar);
				Console.Write("\n\n");
				switch (inputOperation)
				{
					case 'a':
						{
							Console.Write("Please input an address of the house (key): ");
							string address = Console.ReadLine();

							bool overwrite = false;

							if (HousePeopleManage.CheckEntry(address))
							{
								Console.WriteLine("entry already exists. value input will overwrite entry");
								overwrite = true;
							}

							Console.Write("Please input the amount of people in the house (value): ");
							int addressPeopleCount;

							while (!int.TryParse(Console.ReadLine(), out addressPeopleCount))
							{
								Console.Write("Input was invalid\nPlease re-input the amount of people in the house (value): ");
							}

							if (overwrite)
								HousePeopleManage.OverwriteEntry(address, addressPeopleCount);
							else
								HousePeopleManage.AddEntry(address, addressPeopleCount);
							break;
						}
						
					case 'g':
						{
							Console.Write("Please input an address of the house (key): ");

							Console.WriteLine(HousePeopleManage.GetEntry(Console.ReadLine()));
							break;
						}

					case 'i':
						{
							Console.Write(HousePeopleManage.IterateDictionary());
							break;
						}

					default:
						Console.WriteLine("Input unknown. please input a valid character\n\n");
						break;
				}
			}
		}
	}
}
