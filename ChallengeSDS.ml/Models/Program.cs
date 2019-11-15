using System;
using System.Collections.Generic;
using ChallengeSDS.ml.Models;

namespace ChallengeSDS.ml {
	class Program {
		static void Main(string[] args) {

			Console.WriteLine($"Welcome to TheInn.");

			var dateNow = DateTime.Now;
			Console.WriteLine($"Today is { dateNow.DayOfWeek }, it's {dateNow:HH:mm}.");

			IList<Item> Items = new List<Item>{
			new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
			new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
			new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
			new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
			new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 },
			new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
			 };

			var app = new IQualityService(Items);

			for(var i = 1; i < 31; i++) {
				Console.WriteLine(" The Inn Product Inventory | day " + i);
				Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
				Console.WriteLine("name, sellIn, quality");
				for(var p = 0; p < Items.Count; p++) {
					Console.WriteLine(" | Name     | " + Items[p].Name);
					Console.WriteLine(" | SellIn   | " + Items[p].SellIn);
					Console.WriteLine(" | Quality  | " + Items[p].Quality);
				}

				//
				//	Console.WriteLine(Items[p]);
				//}
				Console.WriteLine("");
				app.UpdateQuality();
			}


			//for(var day = 0; `1day < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Day); day++) {
			//	Console.WriteLine(" The Inn Product Inventory | Day" + day);
			//	Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			//	foreach(var item in Items) {
			//		Console.WriteLine($" | Name     | {{Name}} ");
			//		Console.WriteLine($" | SellIn   | {{SellIn}} ");
			//		Console.WriteLine($" | Quality  | {{Quality}} ");
			//	}
			//	Console.WriteLine("");

			//	//var app = new IQualityService(Items);
			//	app.UpdateQuality();
			//}
		}
	}
}

