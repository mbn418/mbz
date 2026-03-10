using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CityForm : Form
{
	/// <summary>
	/// city
	/// </summary>
	public BaseInputControl CityCity => new BaseInputControl(driver, ContainerLocator, "container-CITY____CITY_CITY____", "#CITY____CITY_CITY____");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CountryCountry => new LookupControl(driver, ContainerLocator, "container-CITY__COUNTRY__COUNTRY");
	public SeeMorePage CountryCountrySeeMorePage => new SeeMorePage(driver, "CITY", "CITY__COUNTRY__COUNTRY");

	public CityForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CITY", containerLocator: containerLocator) { }
}
