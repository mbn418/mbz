using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_brokerForm : Form
{
	/// <summary>
	/// photo
	/// </summary>
	public BaseInputControl BrokerPhoto => new BaseInputControl(driver, ContainerLocator, "container-F_BROKER__BROKER__PHOTO", "#F_BROKER__BROKER__PHOTO");

	/// <summary>
	/// Name
	/// </summary>
	public BaseInputControl BrokerName => new BaseInputControl(driver, ContainerLocator, "container-F_BROKER__BROKER__NAME", "#F_BROKER__BROKER__NAME");

	/// <summary>
	/// Birthday
	/// </summary>
	public DateInputControl BrokerBrithdate => new DateInputControl(driver, ContainerLocator, "#F_BROKER__BROKER__BRITHDATE");

	/// <summary>
	/// Email
	/// </summary>
	public BaseInputControl BrokerEmail => new BaseInputControl(driver, ContainerLocator, "container-F_BROKER__BROKER__EMAIL", "#F_BROKER__BROKER__EMAIL");

	public F_brokerForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_BROKER", containerLocator: containerLocator) { }
}
