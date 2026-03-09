using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_propertyForm : Form
{
	/// <summary>
	/// photo
	/// </summary>
	public BaseInputControl PropertyPhoto => new BaseInputControl(driver, ContainerLocator, "container-F_PROPERTY__PROPERTY__PHOTO", "#F_PROPERTY__PROPERTY__PHOTO");

	/// <summary>
	/// title
	/// </summary>
	public BaseInputControl PropertyTitle => new BaseInputControl(driver, ContainerLocator, "container-F_PROPERTY__PROPERTY__TITLE", "#F_PROPERTY__PROPERTY__TITLE");

	/// <summary>
	/// Price
	/// </summary>
	public BaseInputControl PropertyPrice => new BaseInputControl(driver, ContainerLocator, "container-F_PROPERTY__PROPERTY__PRICE", "#F_PROPERTY__PROPERTY__PRICE");

	/// <summary>
	/// brokers Name
	/// </summary>
	public LookupControl BrokerName => new LookupControl(driver, ContainerLocator, "container-F_PROPERTY__BROKER__NAME");
	public SeeMorePage BrokerNameSeeMorePage => new SeeMorePage(driver, "F_PROPERTY", "F_PROPERTY__BROKER__NAME");

	public F_propertyForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_PROPERTY", containerLocator: containerLocator) { }
}
