using System;
using SplitSmart.Models;

namespace SplitSmart.ReportBuilder
{
	public class Report
	{
		private List<ReportViewModel> _finalReport = new List<ReportViewModel>();

		public void Add(List<ReportViewModel> list)
		{
			this._finalReport.AddRange(list);
		}

		public void SetProcessedList(List<ReportViewModel> list)
		{
			this._finalReport = list;
		}

		public List<ReportViewModel> ListParts()
		{
			return this._finalReport;
		}
	}
}

