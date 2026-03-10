using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CountryForm : Form
{
	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl CountryCountry => new BaseInputControl(driver, ContainerLocator, "container-COUNTRY__COUNTRY__COUNTRY", "#COUNTRY__COUNTRY__COUNTRY");

	public CountryForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "COUNTRY", containerLocator: containerLocator) { }
}
