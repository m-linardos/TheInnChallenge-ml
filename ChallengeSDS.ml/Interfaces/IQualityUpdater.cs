using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ChallengeSDS.ml.Models;

namespace ChallengeSDS.ml.Interfaces {
	internal interface IQualityUpdater {
		void UpdateItem(Item item);
	}
}
