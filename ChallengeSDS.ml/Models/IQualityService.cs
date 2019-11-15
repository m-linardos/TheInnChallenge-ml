using System;
using System.Collections.Generic;
using System.Text;	
using ChallengeSDS.ml.Interfaces;

namespace ChallengeSDS.ml.Models {
		/// <summary>
		/// The QualityUpdateService class was created as an intermediary between the IQualityUpdater interface and the classes that are performing the work.
		/// </summary>
		/// <remarks>This offers some protection to our data list of items.</remarks>
		public class IQualityService : IQualityUpdater {
			private const string Brie = "Aged Brie";
			private const string Pass = "Backstage passes to a TAFKAL80ETC concert";
			private const string Sulf = "Sulfuras, Hand of Ragnaros";
			private const string Conj = "Conjured";

			IList<Item> Items;
			public IQualityService(IList<Item> Items) {
				this.Items = Items;
			}
			public void UpdateQuality() {
				foreach(var item in Items) {
					UpdateItem(item);
				}
			}
			public void UpdateItem(Item item) {
				if(item.Name == Sulf) {
					new NoChange();
				}
				else if(item.Name == Brie) {
					new BrieQualityUpdater();
				}
				else if(item.Name == Pass) {
					new PassQualityUpdater();
				}
				else if(item.Name.Contains(Conj)) {
					new StandardQualityUpdater(2);
				}
				else {
					new StandardQualityUpdater();
				}
			}

			public class StandardQualityUpdater : IQualityUpdater {
				private readonly int _calc;
				public StandardQualityUpdater (int calc = 1) {
				   
					 _calc = calc;
					}
			public void UpdateItem(Item item) {
				item.SellIn--;
				if(item.Quality > 0) {
					item.Quality -= _calc * (item.SellIn < 0 ? 2 : 1);
				}
				if(item.Quality < 0) {
					item.Quality = 0;
				}
			}
		}
		public class BrieQualityUpdater : IQualityUpdater {
			public void UpdateItem(Item item) {
				item.SellIn--;
				if(item.Quality < 50) {
					item.Quality++;
				}
			}
		}
		public class PassQualityUpdater : IQualityUpdater {
			public void UpdateItem(Item item) {
				item.SellIn--;
				if(item.SellIn < 0) {
					item.Quality = 0;
				}
				else if(item.SellIn <= 5) {
					item.Quality = item.Quality + 3;
				}
				else if(item.SellIn <= 10) {
					item.Quality = item.Quality + 2;
				}
				else if(item.Quality < 50) {
					item.Quality++;
				}
			}
		}
		public class NoChange : IQualityUpdater {
			public void UpdateItem(Item item) { }
		}
	}
}     
//switch (item.Name)
		//{
		//    case Brie:
		//        item.Quality = BrieQualityUpdate(item.SellIn, item.Quality);
		//        break;

//    case Pass:
//        item.Quality = PassQualityUpdate(item.SellIn, item.Quality);
//        break;

//    case Conj:
//        item.Quality = ConjuredQualityUpdate(item.SellIn, item.Quality);
//        break;

//    default:
//        item.Quality = StandardQualityUpdate(item.SellIn, item.Quality);
//        break;