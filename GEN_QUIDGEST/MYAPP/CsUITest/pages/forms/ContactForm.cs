using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ContactForm : PopupForm
{
	/// <summary>
	/// DATE
	/// </summary>
	public DateInputControl ContactDate => new DateInputControl(driver, ContainerLocator, "#CONTACT__CONTACT__DATE");

	/// <summary>
	/// title
	/// </summary>
	public LookupControl PropertyTitle => new LookupControl(driver, ContainerLocator, "container-CONTACT__PROPERTY__TITLE");
	public SeeMorePage PropertyTitleSeeMorePage => new SeeMorePage(driver, "CONTACT", "CONTACT__PROPERTY__TITLE");

	/// <summary>
	/// CLIENT_NAME
	/// </summary>
	public BaseInputControl ContactClient_name => new BaseInputControl(driver, ContainerLocator, "container-CONTACT__CONTACT__CLIENT_NAME", "#CONTACT__CONTACT__CLIENT_NAME");

	/// <summary>
	/// EMAIL
	/// </summary>
	public BaseInputControl ContactEmail => new BaseInputControl(driver, ContainerLocator, "container-CONTACT__CONTACT__EMAIL", "#CONTACT__CONTACT__EMAIL");

	/// <summary>
	/// PHONE_NUMBER
	/// </summary>
	public BaseInputControl ContactPhone_number => new BaseInputControl(driver, ContainerLocator, "container-CONTACT__CONTACT__PHONE_NUMBER", "#CONTACT__CONTACT__PHONE_NUMBER");

	/// <summary>
	/// DESCRIPTION
	/// </summary>
	public BaseInputControl ContactDescription => new BaseInputControl(driver, ContainerLocator, "container-CONTACT__CONTACT__DESCRIPTION", "#CONTACT__CONTACT__DESCRIPTION");

	public ContactForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CONTACT") { }
}
