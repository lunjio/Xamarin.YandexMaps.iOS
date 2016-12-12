using System;
using System.Drawing;
using Foundation;
using System.ComponentModel;
using UIKit;
using CoreLocation;
using CoreGraphics;
using ObjCRuntime;

namespace Xamarin.YandexMaps.iOS
{
	// @interface YMKMapCoordinate (NSValue)
	[Category]
	[BaseType (typeof(NSValue))]
	public interface YMKMapCoordinate
	{
	
		// +(NSValue *)valueWithYMKMapCoordinate:(YMKMapCoordinate)coordinate;
		[Static, Export ("valueWithYMKMapCoordinate:")]
		NSValue ValueWithYMKMapCoordinate (CLLocationCoordinate2D coordinate);
	
		// -(YMKMapCoordinate)YMKMapCoordinateValue;
		[Export ("YMKMapCoordinateValue")]
		CLLocationCoordinate2D YMKMapCoordinateValue ();
	}

	// @protocol YMKGeoObject <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
    public interface YMKGeoObject
	{

		// @required -(YMKMapCoordinate)coordinate;
		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { [Override] get; [Override][NotImplemented] set; }
	}

	// @protocol YMKAnnotation <YMKGeoObject>
	[Protocol, Model]
	[BaseType (typeof(YMKGeoObject))]
    public interface YMKAnnotation
	{

		// @optional -(NSString *)title;
		[Export ("title")]
		string Title { get; [NotImplemented] set; }

		// @optional -(NSString *)subtitle;
		[Export ("subtitle")]
		string Subtitle { get; [NotImplemented] set; }

		[Override]
		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; set; }
	}

	// @interface YMKAnnotationImage : NSObject
	[BaseType (typeof(NSObject))]
    public interface YMKAnnotationImage
	{

		// -(instancetype)initWithImage:(UIImage *)image highlightedImage:(UIImage *)highlightedImage centerOffset:(CGPoint)centerOffset;
		[Export ("initWithImage:highlightedImage:centerOffset:")]
		IntPtr Constructor (UIImage image, UIImage highlightedImage, CGPoint centerOffset);

		// @property (assign, nonatomic) CGPoint centerOffset;
		[Export ("centerOffset", ArgumentSemantic.UnsafeUnretained)]
		CGPoint CenterOffset { get; set; }

		// @property (retain, nonatomic) UIImage * image;
		[Export ("image", ArgumentSemantic.Retain)]
		UIImage Image { get; set; }

		// @property (retain, nonatomic) UIImage * highlightedImage;
		[Export ("highlightedImage", ArgumentSemantic.Retain)]
		UIImage HighlightedImage { get; set; }

		// +(instancetype)annotationImageWithImage:(UIImage *)image highlightedImage:(UIImage *)highlightedImage centerOffset:(CGPoint)centerOffset;
		[Static, Export ("annotationImageWithImage:highlightedImage:centerOffset:")]
		YMKAnnotationImage AnnotationImageWithImage (UIImage image, UIImage highlightedImage, CGPoint centerOffset);

		// +(instancetype)annotationImageWithImage:(UIImage *)image centerOffset:(CGPoint)centerOffset;
		[Static, Export ("annotationImageWithImage:centerOffset:")]
		YMKAnnotationImage AnnotationImageWithImage (UIImage image, CGPoint centerOffset);

		// +(instancetype)blueAnnotationImage;
		[Static, Export ("blueAnnotationImage")]
		YMKAnnotationImage BlueAnnotationImage ();

		// +(instancetype)greenAnnotationImage;
		[Static, Export ("greenAnnotationImage")]
		YMKAnnotationImage GreenAnnotationImage ();
	}

	// @interface YMKAnnotationView : UIView
	[BaseType (typeof(UIView))]
    public interface YMKAnnotationView
	{

		// -(id)initWithAnnotation:(NSObject<YMKAnnotation> *)annotation reuseIdentifier:(NSString *)reuseIdentifier;
		[Export ("initWithAnnotation:reuseIdentifier:")]
		IntPtr Constructor (NSObject annotation, string reuseIdentifier);

		// @property (readonly, nonatomic) NSString * reuseIdentifier;
		[Export ("reuseIdentifier")]
		string ReuseIdentifier { get; }

		// @property (retain, nonatomic) NSObject<YMKAnnotation> * annotation;
		[Export ("annotation", ArgumentSemantic.Retain)]
		NSObject Annotation { get; set; }

		// @property (nonatomic) CGPoint centerOffset;
		[Export ("centerOffset")]
		CGPoint CenterOffset { get; set; }

		// @property (nonatomic, getter = isSelected) BOOL selected;
		[Export ("selected")]
		bool Selected { [Bind ("isSelected")] get; set; }

		// @property (retain, nonatomic) UIImage * image;
		[Export ("image", ArgumentSemantic.Retain)]
		UIImage Image { get; set; }

		// @property (nonatomic, strong) UIImage * selectedImage;
		[Export ("selectedImage", ArgumentSemantic.Retain)]
		UIImage SelectedImage { get; set; }

		// @property (assign, nonatomic) BOOL alignCenter;
		[Export ("alignCenter", ArgumentSemantic.UnsafeUnretained)]
		bool AlignCenter { get; set; }

		// @property (assign, nonatomic) NSInteger zIndex;
		[Export ("zIndex", ArgumentSemantic.UnsafeUnretained)]
		nint ZIndex { get; set; }

		// @property (assign, nonatomic) BOOL canShowCallout;
		[Export ("canShowCallout", ArgumentSemantic.UnsafeUnretained)]
		bool CanShowCallout { get; set; }

		// @property (assign, nonatomic) CGPoint calloutOffset;
		[Export ("calloutOffset", ArgumentSemantic.UnsafeUnretained)]
		CGPoint CalloutOffset { get; set; }

		// @property (readonly, nonatomic) UIEdgeInsets minimumMargins;
		[Export ("minimumMargins")]
		UIEdgeInsets MinimumMargins { get; }

		// @property (readonly, nonatomic) YMKCalloutView * visibleCalloutView;
		[Export ("visibleCalloutView")]
		YMKCalloutView VisibleCalloutView { get; }

		// -(void)prepareForReuse;
		[Export ("prepareForReuse")]
		void PrepareForReuse ();

		// -(void)setSelected:(BOOL)selected animated:(BOOL)animated;
		[Export ("setSelected:animated:")]
		void SetSelected (bool selected, bool animated);
	}

	// @protocol YMKCalloutContentView <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
    public interface YMKCalloutContentView
	{

		// @optional -(void)setHighlighted:(BOOL)highlighted;
		[Export ("setHighlighted:")]
		void SetHighlighted (bool highlighted);
	}

	// @protocol YMKCalloutViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
    public interface YMKCalloutViewDelegate
	{

		// @optional -(void)calloutViewGotSingleTap:(YMKCalloutView *)view;
		[Export ("calloutViewGotSingleTap:")]
		void CalloutViewGotSingleTap (YMKCalloutView view);

		// @optional -(void)calloutViewGotTapAtLeftAccessoryView:(YMKCalloutView *)view;
		[Export ("calloutViewGotTapAtLeftAccessoryView:")]
		void CalloutViewGotTapAtLeftAccessoryView (YMKCalloutView view);

		// @optional -(void)calloutViewGotTapAtRightAccessoryView:(YMKCalloutView *)view;
		[Export ("calloutViewGotTapAtRightAccessoryView:")]
		void CalloutViewGotTapAtRightAccessoryView (YMKCalloutView view);
	}

	// @interface YMKCalloutView : UIView
	[BaseType (typeof(UIView))]
    public interface YMKCalloutView
	{

		// -(id)initWithReuseIdentifier:(NSString *)reuseIdentifier;
		[Export ("initWithReuseIdentifier:")]
		IntPtr Constructor (string reuseIdentifier);

		// @property (assign, nonatomic) id<YMKCalloutViewDelegate> delegate;
        [Export ("delegate")]
        YMKCalloutViewDelegate Delegate { get; set; }		

		// @property (assign, nonatomic) id<YMKCalloutViewDelegate> delegate;
		[Wrap ("WeakDelegate")]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }

		// @property (retain, nonatomic) UIView * leftView;
		[Export ("leftView", ArgumentSemantic.Retain)]
		UIView LeftView { get; set; }

		// @property (retain, nonatomic) UIView * rightView;
		[Export ("rightView", ArgumentSemantic.Retain)]
		UIView RightView { get; set; }

		// @property (retain, nonatomic) UIView<YMKCalloutContentView> * contentView;
		[Export ("contentView", ArgumentSemantic.Retain)]
		UIView ContentView { get; set; }

		// @property (readonly, assign, nonatomic) BOOL highlighted;
		[Export ("highlighted", ArgumentSemantic.UnsafeUnretained)]
		bool Highlighted { get; }

		// @property (readonly, assign, nonatomic, getter = isHidden) BOOL hidden;
        [Export ("hidden", ArgumentSemantic.UnsafeUnretained), Override]
		bool Hidden { [Bind ("isHidden")] get; [Override][NotImplemented] set;}

		// @property (readonly, copy, nonatomic) NSString * reuseIdentifier;
		[Export ("reuseIdentifier")]
		string ReuseIdentifier { get; }

		// -(void)setLeftView:(UIView *)leftView animated:(BOOL)animated;
		[Export ("setLeftView:animated:")]
		void SetLeftView (UIView leftView, bool animated);

		// -(void)setRightView:(UIView *)rightView animated:(BOOL)animated;
		[Export ("setRightView:animated:")]
		void SetRightView (UIView rightView, bool animated);

		// +(UIView *)defaultDisclosureIndicatorView;
		[Static, Export ("defaultDisclosureIndicatorView")]
		UIView DefaultDisclosureIndicatorView ();

		// -(void)setAnchorPoint:(CGPoint)point boundaryRect:(CGRect)rect;
		[Export ("setAnchorPoint:boundaryRect:")]
		void SetAnchorPoint (CGPoint point, CGRect rect);

		// -(void)hide;
		[Export ("hide")]
		void Hide ();

		// -(void)prepareForReuse;
		[Export ("prepareForReuse")]
		void PrepareForReuse ();

		// -(void)showAtAnnotationView:(YMKAnnotationView *)annotationView;
		[Export ("showAtAnnotationView:")]
		void ShowAtAnnotationView (YMKAnnotationView annotationView);

		// -(void)showAtAnnotationView:(YMKAnnotationView *)annotationView animated:(BOOL)animated;
		[Export ("showAtAnnotationView:animated:")]
		void ShowAtAnnotationView (YMKAnnotationView annotationView, bool animated);

		// -(CGSize)sizeWithContentView:(UIView *)contentView leftView:(UIView *)leftView rightView:(UIView *)rightView boundaryRect:(CGRect)rect;
		[Export ("sizeWithContentView:leftView:rightView:boundaryRect:")]
		CGSize SizeWithContentView (UIView contentView, UIView leftView, UIView rightView, CGRect rect);
	}

	// @interface YMKConfiguration : NSObject
	[BaseType (typeof(NSObject))]
    public interface YMKConfiguration
	{

		// @property (readonly, retain, nonatomic) YMKMapLayersConfiguration * mapLayers;
		[Export ("mapLayers", ArgumentSemantic.Retain)]
		YMKMapLayersConfiguration MapLayers { get; }

		// @property (copy, nonatomic) NSString * apiKey;
		[Export ("apiKey")]
		string ApiKey { get; set; }

		// @property (assign, nonatomic) BOOL useNewBundle;
		[Export ("useNewBundle", ArgumentSemantic.UnsafeUnretained)]
		bool UseNewBundle { get; set; }

		// +(YMKConfiguration *)sharedInstance;
		[Static, Export ("sharedInstance")]
		YMKConfiguration SharedInstance ();
	}

	// @interface YMKDefaultCalloutView : YMKCalloutView
	[BaseType (typeof(YMKCalloutView))]
    public interface YMKDefaultCalloutView
	{

		// @property (nonatomic, strong) id<YMKAnnotation> annotation;
		[Export ("annotation", ArgumentSemantic.Retain)]
		YMKAnnotation Annotation { get; set; }
	}

	// @protocol YMKDraggableAnnotation <YMKAnnotation>
	[Protocol, Model]
	[BaseType (typeof(YMKAnnotation))]
    public interface YMKDraggableAnnotation
	{

		// @required -(void)setCoordinate:(YMKMapCoordinate)coordinate;
		[Export ("setCoordinate:")]
		[Abstract]
		void SetCoordinate (CLLocationCoordinate2D coordinate);

		[Override]
		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; set; }
	}

	// @interface YMKPinAnnotationView : YMKAnnotationView
	[BaseType (typeof(YMKAnnotationView))]
    public interface YMKPinAnnotationView
	{

		// @property (assign, nonatomic) BOOL animatesDrop;
		[Export ("animatesDrop", ArgumentSemantic.UnsafeUnretained)]
		bool AnimatesDrop { get; set; }

		// @property (assign, nonatomic) YMKPinAnnotationColor pinColor;
		[Export ("pinColor", ArgumentSemantic.UnsafeUnretained)]
		nuint PinColor { get; set; }
	}

	// @protocol YMKDraggablePinAnnotationViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
    public interface YMKDraggablePinAnnotationViewDelegate
	{

		// @optional -(void)draggablePinAnnotationViewDidStartInteraction:(YMKDraggablePinAnnotationView *)view;
		[Export ("draggablePinAnnotationViewDidStartInteraction:")]
		void DraggablePinAnnotationViewDidStartInteraction (YMKDraggablePinAnnotationView view);

		// @optional -(void)draggablePinAnnotationViewDidStartMoving:(YMKDraggablePinAnnotationView *)view;
		[Export ("draggablePinAnnotationViewDidStartMoving:")]
		void DraggablePinAnnotationViewDidStartMoving (YMKDraggablePinAnnotationView view);

		// @optional -(void)draggablePinAnnotationViewDidEndMoving:(YMKDraggablePinAnnotationView *)view;
		[Export ("draggablePinAnnotationViewDidEndMoving:")]
		void DraggablePinAnnotationViewDidEndMoving (YMKDraggablePinAnnotationView view);
	}

	// @interface YMKDraggablePinAnnotationView : YMKPinAnnotationView
	[BaseType (typeof(YMKPinAnnotationView))]
    public interface YMKDraggablePinAnnotationView
	{

		// -(id)initWithAnnotation:(id<YMKDraggableAnnotation>)annotation reuseIdentifier:(NSString *)reuseIdentifier;
		[Export ("initWithAnnotation:reuseIdentifier:")]
		IntPtr Constructor (YMKDraggableAnnotation annotation, string reuseIdentifier);

		// @property (readonly, nonatomic, getter = isMoving) BOOL moving;
		[Export ("moving")]
		bool Moving { [Bind ("isMoving")] get; }

		// @property (assign, nonatomic) id<YMKDraggablePinAnnotationViewDelegate> delegate;
        [Export ("delegate")]
        YMKDraggablePinAnnotationViewDelegate Delegate { get; set; }		

		// @property (assign, nonatomic) id<YMKDraggablePinAnnotationViewDelegate> delegate;
		[Wrap ("WeakDelegate")]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }
	}

	// @protocol YMKLocationFetcherDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
    public interface YMKLocationFetcherDelegate
	{

		// @required -(void)locationFetcherDidFetchUserLocation:(YMKLocationFetcher *)locationFetcher;
		[Export ("locationFetcherDidFetchUserLocation:")]
		[Abstract]
		void LocationFetcherDidFetchUserLocation (YMKLocationFetcher locationFetcher);

		// @required -(void)locationFetcher:(YMKLocationFetcher *)locationFetcher didFailWithError:(NSError *)error;
		[Export ("locationFetcher:didFailWithError:")]
		[Abstract]
		void DidFailWithError (YMKLocationFetcher locationFetcher, NSError error);
	}

	// @interface YMKLocationFetcher : NSObject
	[BaseType (typeof(NSObject))]
    public interface YMKLocationFetcher
	{

		// @property (retain, nonatomic) YMKMapView * mapView;
		[Export ("mapView", ArgumentSemantic.Retain)]
		YMKMapView MapView { get; set; }

		// @property (assign, nonatomic) id<YMKLocationFetcherDelegate> delegate;
        [Export ("delegate")]
        YMKLocationFetcherDelegate Delegate { get; set; }		

		// @property (assign, nonatomic) id<YMKLocationFetcherDelegate> delegate;
		[Wrap ("WeakDelegate")]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic, getter = isFetchingLocation) BOOL fetchingLocation;
		[Export ("fetchingLocation", ArgumentSemantic.UnsafeUnretained)]
		bool FetchingLocation { [Bind ("isFetchingLocation")] get; set; }

		// -(void)acquireUserLocationFromMapView;
		[Export ("acquireUserLocationFromMapView")]
		void AcquireUserLocationFromMapView ();
	}

	// @protocol YMKMapImageBuilderDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
    public interface YMKMapImageBuilderDelegate
	{

		// @optional -(YMKAnnotationImage *)mapImageBuilder:(YMKMapImageBuilder *)builder annotationImageForAnnotation:(id<YMKAnnotation>)annotation;
		[Export ("mapImageBuilder:annotationImageForAnnotation:")]
		YMKAnnotationImage AnnotationImageForAnnotation (YMKMapImageBuilder builder, YMKAnnotation annotation);

		// @optional -(void)mapImageBuilder:(YMKMapImageBuilder *)builder builtImage:(UIImage *)image;
		[Export ("mapImageBuilder:builtImage:")]
		void BuiltImage (YMKMapImageBuilder builder, UIImage image);

		// @optional -(void)mapImageBuilderFailedToLoadCompleteImage:(YMKMapImageBuilder *)builder partialImage:(UIImage *)image;
		[Export ("mapImageBuilderFailedToLoadCompleteImage:partialImage:")]
		void PartialImage (YMKMapImageBuilder builder, UIImage image);

		// @optional -(void)mapImageBuilderWasCancelled:(YMKMapImageBuilder *)builder;
		[Export ("mapImageBuilderWasCancelled:")]
		void MapImageBuilderWasCancelled (YMKMapImageBuilder builder);
	}

	// @interface YMKMapImageBuilder : NSObject
	[BaseType (typeof(NSObject))]
    public interface YMKMapImageBuilder
	{

		// -(instancetype)initWithAnnotation:(id<YMKAnnotation>)annotation;
		[Export ("initWithAnnotation:")]
		IntPtr Constructor (YMKAnnotation annotation);

		// -(instancetype)initWithAnnotations:(NSArray *)annotations;
		[Export ("initWithAnnotations:")]
		IntPtr Constructor (NSObject[] annotations);

		// @property (assign, nonatomic) id<YMKMapImageBuilderDelegate> delegate;
        [Export ("delegate", ArgumentSemantic.UnsafeUnretained)]
        YMKMapImageBuilderDelegate Delegate { get; set; }		

		// @property (assign, nonatomic) id<YMKMapImageBuilderDelegate> delegate;
		[Wrap ("WeakDelegate")]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) YMKMapCoordinate centerCoordinate;
		[Export ("centerCoordinate", ArgumentSemantic.UnsafeUnretained)]
		CLLocationCoordinate2D CenterCoordinate { get; set; }

		// @property (assign, nonatomic) CGPoint centerOffset;
		[Export ("centerOffset", ArgumentSemantic.UnsafeUnretained)]
		CGPoint CenterOffset { get; set; }

		// @property (assign, nonatomic) NSUInteger zoomLevel;
		[Export ("zoomLevel", ArgumentSemantic.UnsafeUnretained)]
		nuint ZoomLevel { get; set; }

		// @property (assign, nonatomic) uint16_t layerIdentifier;
		[Export ("layerIdentifier", ArgumentSemantic.UnsafeUnretained)]
		ushort LayerIdentifier { get; set; }

		// @property (assign, nonatomic) CGSize imageSize;
		[Export ("imageSize", ArgumentSemantic.UnsafeUnretained)]
		CGSize ImageSize { get; set; }

		// @property (retain, nonatomic) UIColor * failedImageBgColor;
		[Export ("failedImageBgColor", ArgumentSemantic.Retain)]
		UIColor FailedImageBgColor { get; set; }

		// @property (copy, nonatomic) NSArray * annotations;
		[Export ("annotations", ArgumentSemantic.Copy)]
		NSObject [] Annotations { get; set; }

		// -(void)build;
		[Export ("build")]
		void Build ();

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();
	}

	// @interface YMKMapLayerInfo : NSObject
	[BaseType (typeof(NSObject))]
    public interface YMKMapLayerInfo
	{

		// @property (assign, nonatomic) uint16_t identifier;
		[Export ("identifier", ArgumentSemantic.UnsafeUnretained)]
		ushort Identifier { get; set; }

		// @property (copy, nonatomic) NSString * localizedName;
		[Export ("localizedName")]
		string LocalizedName { get; set; }

		// @property (assign, nonatomic) BOOL auxiliary;
		[Export ("auxiliary", ArgumentSemantic.UnsafeUnretained)]
		bool Auxiliary { get; set; }

		// @property (assign, nonatomic) uint16_t sizeInPixels;
		[Export ("sizeInPixels", ArgumentSemantic.UnsafeUnretained)]
		ushort SizeInPixels { get; set; }

		// @property (assign, nonatomic) BOOL allowsNightMode;
		[Export ("allowsNightMode", ArgumentSemantic.UnsafeUnretained)]
		bool AllowsNightMode { get; set; }
	}

	// @interface YMKMapLayersConfiguration : NSObject
	[BaseType (typeof(NSObject))]
    public interface YMKMapLayersConfiguration
	{

		// @property (readonly, nonatomic) NSArray * infos;
		[Export ("infos")]
		NSObject [] Infos { get; }

		// @property (readonly, nonatomic) BOOL hasServiceLayer;
		[Export ("hasServiceLayer")]
		bool HasServiceLayer { get; }

		// @property (readonly, nonatomic) YMKMapLayerInfo * serviceLayerInfo;
		[Export ("serviceLayerInfo")]
		YMKMapLayerInfo ServiceLayerInfo { get; }

		// -(YMKMapLayerInfo *)infoForLayerWithIdentifier:(uint16_t)identifier;
		[Export ("infoForLayerWithIdentifier:")]
		YMKMapLayerInfo InfoForLayerWithIdentifier (ushort identifier);
	}

	// @interface YMKMapView : UIView
	[BaseType (typeof(UIView))]
    public interface YMKMapView
	{

        // @property (assign, nonatomic) id<YMKMapViewDelegate> delegate;
        [Export ("delegate", ArgumentSemantic.UnsafeUnretained)]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) id<YMKMapViewDelegate> delegate;
        [Wrap ("WeakDelegate")]
        YMKMapViewDelegate Delegate { get; set; }

		// @property (assign, nonatomic) uint16_t visibleLayerIdentifier;
		[Export ("visibleLayerIdentifier", ArgumentSemantic.UnsafeUnretained)]
		ushort VisibleLayerIdentifier { get; set; }

		// @property (assign, nonatomic) YMKMapRegion region;
		[Export ("region", ArgumentSemantic.UnsafeUnretained)]
		YMKMapRegion Region { get; set; }

		// @property (assign, nonatomic) YMKMapCoordinate centerCoordinate;
		[Export ("centerCoordinate", ArgumentSemantic.UnsafeUnretained)]
		CLLocationCoordinate2D CenterCoordinate { get; set; }

		// @property (assign, nonatomic) YMKMapPoint centerMapPoint;
		[Export ("centerMapPoint", ArgumentSemantic.UnsafeUnretained)]
		YMKMapPoint CenterMapPoint { get; set; }

		// @property (readonly, nonatomic) NSUInteger zoomLevel;
		[Export ("zoomLevel")]
		nuint ZoomLevel { get; }

		// @property (readonly, nonatomic) NSArray * annotations;
		[Export ("annotations")]
		NSObject [] Annotations { get; }

		// @property (readonly, nonatomic) YMKMapViewPort viewPort;
		[Export ("viewPort")]
		YMKMapViewPort ViewPort { get; }

		// @property (readonly, assign, nonatomic) double scale;
		[Export ("scale", ArgumentSemantic.UnsafeUnretained)]
		double Scale { get; }

		// @property (retain, nonatomic) id<YMKAnnotation> selectedAnnotation;
		[Export ("selectedAnnotation", ArgumentSemantic.Retain)]
		YMKAnnotation SelectedAnnotation { get; set; }

		// @property (readonly, nonatomic) YMKUserLocation * userLocation;
		[Export ("userLocation")]
		YMKUserLocation UserLocation { get; }

		// @property (readonly, nonatomic) BOOL userLocationVisible;
		[Export ("userLocationVisible")]
		bool UserLocationVisible { get; }

		// @property (assign, nonatomic) BOOL showsUserLocation;
		[Export ("showsUserLocation", ArgumentSemantic.UnsafeUnretained)]
		bool ShowsUserLocation { get; set; }

		// @property (assign, nonatomic) BOOL tracksUserLocation;
		[Export ("tracksUserLocation", ArgumentSemantic.UnsafeUnretained)]
		bool TracksUserLocation { get; set; }

		// @property (assign, nonatomic) BOOL showTraffic;
		[Export ("showTraffic", ArgumentSemantic.UnsafeUnretained)]
		bool ShowTraffic { get; set; }

		// @property (readonly, copy, nonatomic) NSArray * trafficInformers;
		[Export ("trafficInformers", ArgumentSemantic.Copy)]
		NSObject [] TrafficInformers { get; }

		// @property (readonly, assign, nonatomic) BOOL fetchingJams;
		[Export ("fetchingJams", ArgumentSemantic.UnsafeUnretained)]
		bool FetchingJams { get; }

		// @property (assign, nonatomic) BOOL showRoute;
		[Export ("showRoute", ArgumentSemantic.UnsafeUnretained)]
		bool ShowRoute { get; set; }

		// @property (assign, nonatomic) CGFloat angle;
		[Export ("angle", ArgumentSemantic.UnsafeUnretained)]
		nfloat Angle { get; set; }

		// @property (assign, nonatomic) BOOL canUseCompass;
		[Export ("canUseCompass", ArgumentSemantic.UnsafeUnretained)]
		bool CanUseCompass { get; set; }

		// @property (assign, nonatomic) BOOL nightMode;
		[Export ("nightMode", ArgumentSemantic.UnsafeUnretained)]
		bool NightMode { get; set; }

		// -(void)setCenterCoordinate:(YMKMapCoordinate)coordinate animated:(BOOL)animated;
		[Export ("setCenterCoordinate:animated:")]
		void SetCenterCoordinate (CLLocationCoordinate2D coordinate, bool animated);

		// -(void)setRegion:(YMKMapRegion)region animated:(BOOL)animated;
		[Export ("setRegion:animated:")]
		void SetRegion (YMKMapRegion region, bool animated);

		// -(void)setCenterCoordinate:(YMKMapCoordinate)coordinate atZoomLevel:(NSUInteger)zoomLevel animated:(BOOL)animated;
		[Export ("setCenterCoordinate:atZoomLevel:animated:")]
		void SetCenterCoordinate (CLLocationCoordinate2D coordinate, nuint zoomLevel, bool animated);

		// -(YMKAnnotationView *)dequeueReusableAnnotationViewWithIdentifier:(NSString *)identifier;
		[Export ("dequeueReusableAnnotationViewWithIdentifier:")]
		YMKAnnotationView DequeueReusableAnnotationViewWithIdentifier (string identifier);

		// -(YMKCalloutView *)dequeueReusableCalloutViewWithIdentifier:(NSString *)identifier;
		[Export ("dequeueReusableCalloutViewWithIdentifier:")]
		YMKCalloutView DequeueReusableCalloutViewWithIdentifier (string identifier);

		// -(void)addAnnotation:(id<YMKAnnotation>)annotation;
		[Export ("addAnnotation:")]
		void AddAnnotation (YMKAnnotation annotation);

		// -(void)addAnnotations:(NSArray *)annotations;
		[Export ("addAnnotations:")]
		void AddAnnotations (NSObject[] annotations);

		// -(void)removeAnnotation:(id<YMKAnnotation>)annotation;
		[Export ("removeAnnotation:")]
		void RemoveAnnotation (YMKAnnotation annotation);

		// -(void)removeAnnotations:(NSArray *)annotations;
		[Export ("removeAnnotations:")]
		void RemoveAnnotations (NSObject[] annotations);

		// -(void)scrollToAnnotation:(id<YMKAnnotation>)annotation animated:(BOOL)animated;
		[Export ("scrollToAnnotation:animated:")]
		void ScrollToAnnotation (YMKAnnotation annotation, bool animated);

		// -(YMKAnnotationView *)viewForAnnotation:(id<YMKAnnotation>)annotation;
		[Export ("viewForAnnotation:")]
		YMKAnnotationView ViewForAnnotation (YMKAnnotation annotation);

		// -(CGPoint)convertLLToMapView:(YMKMapCoordinate)coord;
		[Export ("convertLLToMapView:")]
		CGPoint ConvertLLToMapView (CLLocationCoordinate2D coord);

		// -(YMKMapCoordinate)convertMapViewPointToLL:(CGPoint)point;
		[Export ("convertMapViewPointToLL:")]
		CLLocationCoordinate2D ConvertMapViewPointToLL (CGPoint point);

		// -(CGPoint)convertMapPointToMapView:(YMKMapPoint)point;
		[Export ("convertMapPointToMapView:")]
		CGPoint ConvertMapPointToMapView (YMKMapPoint point);

		// -(YMKMapPoint)convertMapViewPointToMapPoint:(CGPoint)point;
		[Export ("convertMapViewPointToMapPoint:")]
		YMKMapPoint ConvertMapViewPointToMapPoint (CGPoint point);

		// -(YMKMapRegion)fitRegion:(YMKMapRegion)region;
		[Export ("fitRegion:")]
		YMKMapRegion FitRegion (YMKMapRegion region);

		// -(void)setAngle:(CGFloat)angle animated:(BOOL)animated;
		[Export ("setAngle:animated:")]
		void SetAngle (nfloat angle, bool animated);

		// -(void)dismissHeadingCalibrationDisplay;
		[Export ("dismissHeadingCalibrationDisplay")]
		void DismissHeadingCalibrationDisplay ();

		// +(unsigned long long)calculateCacheSize:(NSError **)error;
		[Static, Export ("calculateCacheSize:")]
		ulong CalculateCacheSize (out NSError error);

		// +(void)clearCache;
		[Static, Export ("clearCache")]
		void ClearCache ();

		// -(void)zoomIn;
		[Export ("zoomIn")]
		void ZoomIn ();

		// -(void)zoomOut;
		[Export ("zoomOut")]
		void ZoomOut ();
	}

	// @protocol YMKMapViewDelegate <NSObject>	
	[BaseType (typeof(NSObject))]
    [Model][Protocol]
	public interface YMKMapViewDelegate
	{
		// @optional -(YMKAnnotationView *)mapView:(YMKMapView *)mapView viewForAnnotation:(id<YMKAnnotation>)annotation;
		[Export ("mapView:viewForAnnotation:")]
		YMKAnnotationView ViewForAnnotation (YMKMapView mapView, YMKAnnotation annotation);

		// @optional -(YMKCalloutView *)mapView:(YMKMapView *)view calloutViewForAnnotation:(id<YMKAnnotation>)annotation;
		[Export ("mapView:calloutViewForAnnotation:")]
		YMKCalloutView CalloutViewForAnnotation (YMKMapView view, YMKAnnotation annotation);

		// @optional -(void)mapView:(YMKMapView *)mapView annotationView:(YMKAnnotationView *)view calloutAccessoryControlTapped:(UIControl *)control;
		[Export ("mapView:annotationView:calloutAccessoryControlTapped:")]
		void CalloutAccessoryControlTapped (YMKMapView mapView, YMKAnnotationView view, UIControl control);

		// @optional -(void)mapView:(YMKMapView *)mapView annotationViewCalloutTapped:(YMKAnnotationView *)view;
		[Export ("mapView:annotationViewCalloutTapped:")]
		void AnnotationViewCalloutTapped (YMKMapView mapView, YMKAnnotationView view);

		// @optional -(void)mapView:(YMKMapView *)mapView didAddAnnotationViews:(NSArray *)views;
		[Export ("mapView:didAddAnnotationViews:")]
		void DidAddAnnotationViews (YMKMapView mapView, NSObject[] views);

		// @optional -(void)mapView:(YMKMapView *)mapView regionDidChangeAnimated:(BOOL)animated;
		[Export ("mapView:regionDidChangeAnimated:")]
		void RegionDidChangeAnimated (YMKMapView mapView, bool animated);

		// @optional -(void)mapView:(YMKMapView *)mapView regionWillChangeAnimated:(BOOL)animated;
		[Export ("mapView:regionWillChangeAnimated:")]
		void RegionWillChangeAnimated (YMKMapView mapView, bool animated);

		// @optional -(void)mapViewWasDragged:(YMKMapView *)mapView;
		[Export ("mapViewWasDragged:")]
		void MapViewWasDragged (YMKMapView mapView);

		// @optional -(BOOL)mapViewShouldFollowUserLocation:(YMKMapView *)mapView;
		[Export ("mapViewShouldFollowUserLocation:")]
		bool MapViewShouldFollowUserLocation (YMKMapView mapView);

		// @optional -(BOOL)mapViewShouldDisplayHeadingCalibration:(YMKMapView *)mapView;
		[Export ("mapViewShouldDisplayHeadingCalibration:")]
		bool MapViewShouldDisplayHeadingCalibration (YMKMapView mapView);

		// @optional -(void)mapView:(YMKMapView *)mapView locationManagerDidReceiveError:(NSError *)error;
		[Export ("mapView:locationManagerDidReceiveError:")]
		void LocationManagerDidReceiveError (YMKMapView mapView, NSError error);

		// @optional -(void)mapView:(YMKMapView *)mapView didUpdateUserLocation:(YMKUserLocation *)userLocation;
		[Export ("mapView:didUpdateUserLocation:")]
		void DidUpdateUserLocation (YMKMapView mapView, YMKUserLocation userLocation);

		// @optional -(void)mapView:(YMKMapView *)mapView gotSingleTapAtCoordinate:(YMKMapCoordinate)coordinate;
		[Export ("mapView:gotSingleTapAtCoordinate:")]
		void GotSingleTapAtCoordinate (YMKMapView mapView, CLLocationCoordinate2D coordinate);

		// @optional -(void)mapView:(YMKMapView *)mapView gotTapAndHoldAtCoordinate:(YMKMapCoordinate)coordinate;
		[Export ("mapView:gotTapAndHoldAtCoordinate:")]
		void GotTapAndHoldAtCoordinate (YMKMapView mapView, CLLocationCoordinate2D coordinate);

		// @optional -(void)mapViewDidResetRotationAngle:(YMKMapView *)mapView;
		[Export ("mapViewDidResetRotationAngle:")]
		void MapViewDidResetRotationAngle (YMKMapView mapView);

		// @optional -(CGRect)mapViewVisibleRect:(YMKMapView *)mapView;
		[Export ("mapViewVisibleRect:")]
		CGRect MapViewVisibleRect (YMKMapView mapView);
	}

	// @interface YMKRuler : UIView
	[BaseType (typeof(UIView))]
    public interface YMKRuler
	{

		// @property (assign, nonatomic) double scale;
		[Export ("scale", ArgumentSemantic.UnsafeUnretained)]
		double Scale { get; set; }
	}

	// @interface YMKTrafficInformer : NSObject <NSCoding>
	[BaseType (typeof(NSCoding))]
    public interface YMKTrafficInformer
	{

		// @property (assign, nonatomic) YMKMapCoordinate coord;
		[Export ("coord", ArgumentSemantic.UnsafeUnretained)]
		CLLocationCoordinate2D Coord { get; set; }

		// @property (assign, nonatomic) NSInteger value;
		[Export ("value", ArgumentSemantic.UnsafeUnretained)]
		nint Value { get; set; }

		// @property (assign, nonatomic) YMKTrafficInformerColor color;
		[Export ("color", ArgumentSemantic.UnsafeUnretained)]
		YMKTrafficInformerColor Color { get; set; }

		// @property (retain, nonatomic) NSDate * expirationDate;
		[Export ("expirationDate", ArgumentSemantic.Retain)]
		NSDate ExpirationDate { get; set; }

		// @property (retain, nonatomic) NSString * city;
		[Export ("city", ArgumentSemantic.Retain)]
		string City { get; set; }

		[Export ("encodeWithCoder:")]
		[Override]
		void EncodeTo (NSCoder encoder);
	}

	// @interface YMKUserLocation : NSObject <YMKAnnotation>
	[BaseType (typeof(YMKAnnotation))]
    public interface YMKUserLocation
	{

		// @property (readonly, nonatomic) CLLocation * location;
		[Export ("location")]
		CLLocation Location { get; }

		// @property (readonly, nonatomic) NSString * title;
		[Override]
		[Export ("title")]
		string Title { get; [NotImplemented] set; }

		// @property (copy, nonatomic) NSString * subtitle;
		[Override]
		[Export ("subtitle")]
		string Subtitle { get; set; }

		// @property (readonly, nonatomic, getter = isUpdating) BOOL updating;
		[Export ("updating")]
		bool Updating { [Bind ("isUpdating")] get; }
	}

}

