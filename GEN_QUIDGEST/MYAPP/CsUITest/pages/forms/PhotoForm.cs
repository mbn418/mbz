using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PhotoForm : Form
{
	/// <summary>
	/// PHOTO
	/// </summary>
	public BaseInputControl Photo_albumPhoto => new BaseInputControl(driver, ContainerLocator, "container-PHOTO__PHOTO_ALBUM__PHOTO", "#PHOTO__PHOTO_ALBUM__PHOTO");

	/// <summary>
	/// title
	/// </summary>
	public BaseInputControl Photo_albumTitle => new BaseInputControl(driver, ContainerLocator, "container-PHOTO__PHOTO_ALBUM__TITLE", "#PHOTO__PHOTO_ALBUM__TITLE");

	/// <summary>
	/// title
	/// </summary>
	public LookupControl PropertyTitle => new LookupControl(driver, ContainerLocator, "container-PHOTO__PROPERTY__TITLE");
	public SeeMorePage PropertyTitleSeeMorePage => new SeeMorePage(driver, "PHOTO", "PHOTO__PROPERTY__TITLE");

	public PhotoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PHOTO", containerLocator: containerLocator) { }
}
