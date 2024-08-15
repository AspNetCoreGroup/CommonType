using ModelLibrary.Model.Devices.Measurument;

namespace ModelLibrary.Responses
{
	public class GetMeasurementsResponse
	{
		public required List<Measurement> Measurements { get; set; }
	}
}