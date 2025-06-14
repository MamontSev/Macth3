using System;

using Mathc3.Data.GameItem;

namespace Mathc3.Core.Item
{
	public class ItemInGameType
	{
		public readonly ShapeType SelfShapeType;
		public readonly FrameType SelfFrameType;
		public readonly ContentType SelfContentType;
		public ItemInGameType( ShapeType shapeType , FrameType frameType , ContentType contentType )
		{
			SelfShapeType = shapeType;
			SelfFrameType = frameType;
			SelfContentType = contentType;

		}

		public bool Equals( ItemInGameType other )
		{
			if( other == null )
				return false;
			return  SelfShapeType == other.SelfShapeType 
					&& SelfFrameType == other.SelfFrameType 
					&& SelfContentType == other.SelfContentType ;
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(SelfShapeType , SelfFrameType , SelfContentType);
		}
	}
}
