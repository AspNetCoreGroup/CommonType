using ModelLibrary.Model.Devices;

namespace ModelLibrary.Responses
{
	public class GetMeasurementsResponse
	{
		public required List<MeasurementData> Measurements { get; set; }
	}
}