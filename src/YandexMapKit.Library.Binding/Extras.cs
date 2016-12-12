using System.Runtime.InteropServices;
using ObjCRuntime;
using MapKit;
using CoreLocation;

namespace Xamarin.YandexMaps.iOS
{
	public partial class YandexMapKitGlobal
	{
		//        [DllImportAttribute("__Internal", EntryPoint = "YMKMapRegionFromMapRect")]
		//        private static extern IntPtr YMKMapRegionFromMapRect (IntPtr rect);
		//
		//        public static YMKMapRegion RegionFromMapRect (YMKMapRect rect)
		//        {
		//            IntPtr rectPtr = Marshal.AllocHGlobal (Marshal.SizeOf (rect));
		//
		//            IntPtr resultPtr;
		//            YMKMapRegion result;
		//
		//            try {
		//                Marshal.StructureToPtr ((object)rect, rectPtr, true);
		//
		//                resultPtr = YMKMapRegionFromMapRect (rectPtr);
		//                result = (YMKMapRegion)Marshal.PtrToStructure (resultPtr, typeof(YMKMapRegion));
		//            }
		//            finally {
		//                Marshal.FreeHGlobal (rectPtr);
		//            }
		//            return result;
		//
		//            //extern YMKMapRegion YMKMapRegionFromMapRect(YMKMapRect rect);
		//        }
		//
		//        [DllImportAttribute("__Internal", EntryPoint = "YMKMapRectBoundingAnnotations")]
		//        private static extern YMKMapRect YMKMapRectBoundingAnnotations (IntPtr annotations);
		//
		//        public static YMKMapRect RectBoundingAnnotations (NSObject[] annotations)
		//        {
		//            var objs = new List<NSObject>();
		//
		//            foreach (var a in annotations)
		//                objs.Add(a);
		//
		//            NSArray arry = NSArray.FromNSObjects(objs.ToArray());
		//            return YMKMapRectBoundingAnnotations(arry.Handle);
		//        }


		// imports from iOS MapKit
		[DllImport (Constants.MapKitLibrary, EntryPoint = "MKCoordinateRegionForMapRect")]
		extern static public MKCoordinateRegion MKCoordinateRegionForMapRect (MKMapRect rect);

		[DllImport (Constants.MapKitLibrary, EntryPoint = "MKMapPointForCoordinate")]
		extern static public MKMapPoint MKMapPointForCoordinate (CLLocationCoordinate2D rect);

		public static YMKMapRegion MKCoordinateRegionToYMKMapRegion (MKCoordinateRegion region)
		{
			var ymkregion = new YMKMapRegion ();
			ymkregion.Center = new CLLocationCoordinate2D (region.Center.Latitude, region.Center.Longitude);
			ymkregion.Span = new YMKMapRegionSize ();
			ymkregion.Span.LatitudeDelta = region.Span.LatitudeDelta;
			ymkregion.Span.LongitudeDelta = region.Span.LongitudeDelta;

			return ymkregion;
		}
	}
}

