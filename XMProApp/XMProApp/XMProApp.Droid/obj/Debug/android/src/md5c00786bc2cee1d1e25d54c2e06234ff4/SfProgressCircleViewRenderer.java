package md5c00786bc2cee1d1e25d54c2e06234ff4;


public class SfProgressCircleViewRenderer
	extends md5b60ffeb829f638581ab2bb9b1a7f4f3f.VisualElementRenderer_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDraw:(Landroid/graphics/Canvas;)V:GetOnDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.SfPullToRefresh.XForms.Droid.SfProgressCircleViewRenderer, Syncfusion.SfPullToRefresh.XForms.Android, Version=15.2451.0.43, Culture=neutral, PublicKeyToken=null", SfProgressCircleViewRenderer.class, __md_methods);
	}


	public SfProgressCircleViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == SfProgressCircleViewRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfPullToRefresh.XForms.Droid.SfProgressCircleViewRenderer, Syncfusion.SfPullToRefresh.XForms.Android, Version=15.2451.0.43, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SfProgressCircleViewRenderer (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == SfProgressCircleViewRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfPullToRefresh.XForms.Droid.SfProgressCircleViewRenderer, Syncfusion.SfPullToRefresh.XForms.Android, Version=15.2451.0.43, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public SfProgressCircleViewRenderer (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == SfProgressCircleViewRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfPullToRefresh.XForms.Droid.SfProgressCircleViewRenderer, Syncfusion.SfPullToRefresh.XForms.Android, Version=15.2451.0.43, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void onDraw (android.graphics.Canvas p0)
	{
		n_onDraw (p0);
	}

	private native void n_onDraw (android.graphics.Canvas p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
