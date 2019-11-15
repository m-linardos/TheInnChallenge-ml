using System;
using System.Collections.Generic;
using ChallengeSDS.ml.Models;

namespace ChallengeSDS.ml {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("The Inn");

			IList<Item> Items = new List<Item>{
			new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
			new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
			new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
			new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
			new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 },
			new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
			 };

			// The following code was modeled after a project by Ian Kent  https://github.com/ianrkent/GuildedRoseKata/blob/0f3e871c2b12bb769f267b7bac7e459c8f4bdf3f/GuildedRoseRunner.cs	
		
			var app = new IQualityService(Items);
			var daysInTheCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Day);

			for(var day = 0; day < daysInTheCurrentMonth; day++) {
				Console.WriteLine("TheInn - day " + day + " ---- ");
				Console.WriteLine("name, sellIn, quality");
				for(var j = 0; j < Items.Count; j++) {
					System.Console.WriteLine(Items[j]);
				}
				Console.WriteLine("");
				app.UpdateQuality();
			}
		}
	}
}
