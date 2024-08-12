using System;
namespace ModelLibrary.Enums
{
	public enum RequestType : byte
	{
		Get = 0,
		Post = 1,
		Put = 2,
		Delete = 3,
        [Obsolete("Правильная работа с Patch пока не предусмотрена")]
		Patch = 4
	}
}

