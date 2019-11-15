using ApprovalTests.Reporters;
using ChallengeSDS.ml.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ChallengeSDS.ml.Models.IQualityService;

namespace ChallengeSDS.mlTests {
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class IQualityServiceTests {
		[TestMethod]
		public void StandardQualityUpdaterTest() {
			Item item = new Item { Name = "anyItem", SellIn = 10, Quality = 20 };

			var result = new StandardQualityUpdater(1);
			result.UpdateItem(item);
			int startQuality = item.Quality;
			//Act

			//Assert
			Assert.AreEqual(19, startQuality);
		}

		[TestMethod]
		public void BrieQualityUpdaterTest() {
			//Arrange
			Item item = new Item { Name = "Brie", SellIn = 2, Quality = 3 };

			var resualt = new BrieQualityUpdater();
			resualt.UpdateItem(item);
			int startQuality = item.Quality;

			//Assert
			Assert.AreEqual(4, startQuality);
		}

		[TestMethod]
		public void PassQualityUpdaterTest() {
			//Arrange
			Item item = new Item {
				Name = "Pass",
				SellIn = 6,
				Quality = 20
			};

			var result = new PassQualityUpdater();
			result.UpdateItem(item);
			int startQuality = item.Quality;

			//Assert
			Assert.AreEqual(22, startQuality);
		}

		[TestMethod]
		public void NoChangeTest() {
			//Arrange
			Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };

			var result = new NoChange();
			result.UpdateItem(item);
			int startSellIn = item.SellIn;

			//Assert
			Assert.AreEqual(0, startSellIn);
		}

	}
}
