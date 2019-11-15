using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ChallengeSDS.ml.Models;

namespace ChallengeSDS.ml.Interfaces {
	public interface IQualityUpdater {
		void UpdateItem(Item item);
	}
}
