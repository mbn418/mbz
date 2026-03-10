using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Typology (Typology)
	/// </summary>
	public class ArrayTypology : Array<decimal>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayTypology _instance = new ArrayTypology();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayTypology Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// No Bedrooms
		/// </summary>
		public const decimal E_1_1 = 1M;
		/// <summary>
		/// one bedroom
		/// </summary>
		public const decimal E_2_2 = 2M;
		/// <summary>
		/// 2 bredrooms
		/// </summary>
		public const decimal E_3_3 = 3M;
		/// <summary>
		/// 3 bedrooms
		/// </summary>
		public const decimal E_4_4 = 4M;
		/// <summary>
		/// More
		/// </summary>
		public const decimal E_5_5 = 5M;
		/// <summary>
		/// 
		/// </summary>
		public const decimal E__6 = M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayTypology"/> class from being created.
		/// </summary>
		private ArrayTypology() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "NO_BEDROOMS09923", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "ONE_BEDROOM55017", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "_2_BREDROOMS10489", HelpId = "", Group = "" } },
				{ E_4_4, new ArrayElement() { ResourceId = "_3_BEDROOMS27305", HelpId = "", Group = "" } },
				{ E_5_5, new ArrayElement() { ResourceId = "MORE38452", HelpId = "", Group = "" } },
				{ E__6, new ArrayElement() { ResourceId = "", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(decimal cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<decimal> GetElements()
		{
			return Instance.GetElementsImpl();
		}

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static ArrayElement GetElement(string cod)
		{
            return Instance.GetElementImpl(decimal.Parse(cod));
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<decimal, string> GetDictionary()
		{
			return Instance.GetDictionaryImpl();
		}

		/// <summary>
		/// Gets the help identifier.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string GetHelpId(string cod)
		{
			return Instance.GetHelpIdImpl(decimal.Parse(cod));
		}
	}
}
