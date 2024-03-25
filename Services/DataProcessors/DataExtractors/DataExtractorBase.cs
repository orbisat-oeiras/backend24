﻿using backend24.Models;
using backend24.Services.DataProviders;

namespace backend24.Services.DataProcessors.DataExtractors
{
	/// <summary>
	/// Base class for data extractors, i.e., classes which extract individual pieces of data from a SerialProvider
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class DataExtractorBase<T> : DataProcessorBase<string[], T>
	{
		/// <summary>
		/// Indexes of the required data pieces in the array provided by SerialProvider
		/// </summary>
		protected SerialProvider.DataIndexes[] _sourceIndexes = [];

		protected DataExtractorBase([FromKeyedServices(ServiceKeys.SerialProvider)]IDataProvider<string[]> provider) : base(provider) {
		}

		/// <summary>
		/// Convert the data piece into the proper format
		/// </summary>
		/// <param name="data">Data piece as a string</param>
		/// <returns>Data piece as <typeparamref name="T"/></returns>
		protected abstract T Convert(IEnumerable<string> data);
		protected override EventData<T> Process(EventData<string[]> data) {
			return new EventData<T>() {
				DataStamp = data.DataStamp,
				// Select a subset of the data pieces
				Data = Convert(_sourceIndexes.Select(x => data.Data[(int)x]))
			};
		}
	}
}
