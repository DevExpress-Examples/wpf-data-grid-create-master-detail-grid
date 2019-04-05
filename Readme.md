<!-- default file list -->
*Files to look at*:

* [Window1.xaml](./CS/Window1.xaml) (VB: [Window1.xaml](./VB/Window1.xaml))
* [Window1.xaml.cs](./CS/Window1.xaml.cs) (VB: [Window1.xaml.vb](./VB/Window1.xaml.vb))
<!-- default file list end -->
# How to create a master-detail grid


<p>In the 12.1 version we implemented a Master-Detail feature, and now we provide it out of the box. We have added a new solution, which shows how to use our new approach.</p><br />
<p>With later versions of our controls you can use the previous workaround:</p><p>To accomplish this, it is necessary to use one <strong>GridControl</strong> as a template for a data row of another <strong>GridControl</strong>.</p><p>Limitations of the previous approach:</p><p>Vertical scrolling is performed per master row. For an example on how to implement vertical scrolling of details, please see 'Persistent Row State' in the DXGrid's demo.</p>

<br/>


