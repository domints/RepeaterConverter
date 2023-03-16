using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace RepeaterConverter
{
	[XmlRoot(ElementName="link")]
	public class Link {
		[XmlAttribute(AttributeName="rel")]
		public string Rel { get; set; }
		[XmlAttribute(AttributeName="href")]
		public string Href { get; set; }
		[XmlAttribute(AttributeName="type")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName="item")]
	public class Item {
		[XmlElement(ElementName="type")]
		public string Type { get; set; }
		[XmlElement(ElementName="name")]
		public string Name { get; set; }
		[XmlElement(ElementName="value")]
		public string Value { get; set; }
		[XmlElement(ElementName="description")]
		public string Description { get; set; }
		[XmlElement(ElementName="preferedColor")]
		public string PreferedColor { get; set; }
	}

	[XmlRoot(ElementName="dictionary")]
	public class Dictionary {
		[XmlElement(ElementName="item")]
		public List<Item> Item { get; set; }
	}

	[XmlRoot(ElementName="qrg")]
	public class Qrg {
		[XmlAttribute(AttributeName="type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName="location")]
	public class Location {
		[XmlElement(ElementName="locator")]
		public string Locator { get; set; }
		[XmlElement(ElementName="latitude")]
		public string Latitude { get; set; }
		[XmlElement(ElementName="longitude")]
		public string Longitude { get; set; }
		[XmlElement(ElementName="altitudeOverSea")]
		public string AltitudeOverSea { get; set; }
		[XmlElement(ElementName="altitudeOverGround")]
		public string AltitudeOverGround { get; set; }
	}

	[XmlRoot(ElementName="ctcss")]
	public class Ctcss {
		[XmlAttribute(AttributeName="type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName="repeater")]
	public class Repeater {
		[XmlElement(ElementName="qra")]
		public string Qra { get; set; }
		[XmlElement(ElementName="id")]
		public string Id { get; set; }
		[XmlElement(ElementName="hash")]
		public string Hash { get; set; }
		[XmlElement(ElementName="created")]
		public string Created { get; set; }
		[XmlElement(ElementName="updated")]
		public string Updated { get; set; }
		[XmlElement(ElementName="statusInt")]
		public string StatusInt { get; set; }
		[XmlElement(ElementName="status")]
		public string Status { get; set; }
		[XmlElement(ElementName="modeInt")]
		public string ModeInt { get; set; }
		[XmlElement(ElementName="mode")]
		public List<string> Mode { get; set; }
		[XmlElement(ElementName="bandInt")]
		public string BandInt { get; set; }
		[XmlElement(ElementName="band")]
		public List<string> Band { get; set; }
		[XmlElement(ElementName="qrg")]
		public List<Qrg> Qrg { get; set; }
		[XmlElement(ElementName="country")]
		public string Country { get; set; }
		[XmlElement(ElementName="qth")]
		public string Qth { get; set; }
		[XmlElement(ElementName="location")]
		public Location Location { get; set; }
		[XmlElement(ElementName="activationInt")]
		public string ActivationInt { get; set; }
		[XmlElement(ElementName="activation")]
		public List<string> Activation { get; set; }
		[XmlElement(ElementName="ctcss")]
		public List<Ctcss> Ctcss { get; set; }
		[XmlElement(ElementName="operator")]
		public List<string> Operator { get; set; }
		[XmlElement(ElementName="link")]
		public List<string> Link { get; set; }
		[XmlElement(ElementName="source")]
		public string Source { get; set; }
		[XmlElement(ElementName="feedback")]
		public string Feedback { get; set; }
		[XmlElement(ElementName="licenseExpiryDate")]
		public string LicenseExpiryDate { get; set; }
		[XmlElement(ElementName="trxPower")]
		public string TrxPower { get; set; }
		[XmlElement(ElementName="echolink")]
		public string Echolink { get; set; }
		[XmlElement(ElementName="remarks")]
		public string Remarks { get; set; }
	}

	[XmlRoot(ElementName="repeaters")]
	public class Repeaters {
		[XmlElement(ElementName="repeater")]
		public List<Repeater> Repeater { get; set; }
	}

	[XmlRoot(ElementName="rxf")]
	public class Rxf {
		[XmlElement(ElementName="link")]
		public Link Link { get; set; }
		[XmlElement(ElementName="updated")]
		public string Updated { get; set; }
		[XmlElement(ElementName="generated")]
		public string Generated { get; set; }
		[XmlElement(ElementName="generator")]
		public string Generator { get; set; }
		[XmlElement(ElementName="dictionary")]
		public Dictionary Dictionary { get; set; }
		[XmlElement(ElementName="repeaters")]
		public Repeaters Repeaters { get; set; }
		[XmlAttribute(AttributeName="version")]
		public string Version { get; set; }
	}
}