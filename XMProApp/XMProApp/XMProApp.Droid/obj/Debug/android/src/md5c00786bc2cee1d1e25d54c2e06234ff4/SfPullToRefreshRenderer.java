package md5c00786bc2cee1d1e25d54c2e06234ff4;


public class SfPullToRefreshRenderer
	extends md5b60ffeb829f638581ab2bb9b1a7f4f3f.VisualElementRenderer_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInterceptTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnInterceptTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.SfPullToRefresh.XForms.Droid.SfPullToRefreshRenderer, Syncfusion.SfPullToRefresh.XForms.Android, Version=15.2451.0.43, Culture=neutral, PublicKeyToken=null", SfPullToRefreshRenderer.class, __md_methods);
	}


	public SfPullToRefreshRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == SfPullToRefreshRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfPullToRefresh.XForms.Droid.SfPullToRefreshRenderer, Syncfusion.SfPullToRefresh.XForms.Android, Version=15.2451.0.43, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SfPullToRefreshRenderer (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == SfPullToRefreshRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfPullToRefresh.XForms.Droid.SfPullToRefreshRenderer, Syncfusion.SfPullToRefresh.XForms.Android, Version=15.2451.0.43, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public SfPullToRefreshRenderer (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == SfPullToRefreshRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfPullToRefresh.XForms.Droid.SfPullToRefreshRenderer, Syncfusion.SfPullToRefresh.XForms.Android, Version=15.2451.0.43, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public boolean onInterceptTouchEvent (android.view.MotionEvent p0)
	{
		return n_onInterceptTouchEvent (p0);
	}

	private native boolean n_onInterceptTouchEvent (android.view.MotionEvent p0);


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);

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
