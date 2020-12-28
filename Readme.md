<!-- default file list -->
*Files to look at*:

* [ViewModel.cs](./CS/ViewModel.cs) (VB: [ViewModel.vb](./VB/ViewModel.vb))
* [Window1.xaml](./CS/Window1.xaml) (VB: [Window1.xaml](./VB/Window1.xaml))
<!-- default file list end -->
# How to create a master-detail grid


In the 12.1 version we implemented a [Master-Detail](https://docs.devexpress.com/WPF/119851/controls-and-libraries/data-grid/master-detail/data-grid-in-details) feature, and now we provide it out of the box. We have added a new solution, which shows how to use our new approach.

See also: [Master-Detail Mode Limitations](https://docs.devexpress.com/WPF/11841/controls-and-libraries/data-grid/master-detail/master-detail-mode-limitations)

---

**With later versions of our controls you can use the previous workaround:**

To accomplish this, it is necessary to use one <strong>GridControl</strong> as a template for a data row of another <strong>GridControl</strong>.

**Limitations of the previous approach:**

Vertical scrolling is performed per master row. For an example on how to implement vertical scrolling of details, please see *Persistent Row State* in the DXGrid's demo.
