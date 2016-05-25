# DnsHelper
Utility application to quickly swap between DNS servers for services such as [http://www.unblock-us.com](http://www.unblock-us.com) and [https://unlocator.com/](https://unlocator.com/).

This utility is in no way affiliated with any of the companies providing the DNS services. It is a custom tool I made as I wanted a simple way to switch between different DNS values quickly.

![Demo](https://raw.githubusercontent.com/sverrirs/DnsHelper/master/examples/v4.1/demo01.gif "Animated demonstration of the tool")

# Download
A binary release can be downloaded from [Releases](https://github.com/sverrirs/DnsHelper/releases). 
It is a single unsigned executable that requires administrator privileges to run, don't forget to also download the accompanying `dns.json` file.
Elevated privileges are necessary to be able to set the DNS values and restart the Network Adapter.

## Fast DNS configuration
With the recent arms race between VPN/DNS suppliers and Netflix. The DNS server addresses are likely to start changing very rapidly. 
This tool helps with applying new DNS values and restarting network adapters on Windows with only a few clicks.

## Can set any DNS values
The tool will apply any DNS IP values you type into it and will restart the network adaptor to make sure that the new values are read and applied correctly
![Applied](https://raw.githubusercontent.com/sverrirs/DnsHelper/master/examples/v4.1/setting-dns.jpg "A IPv4 sheet showing values that the tool updated")

## Resetting to automatic
The tool can also quickly restore your DNS settings to "automatic"
![Auto](https://raw.githubusercontent.com/sverrirs/DnsHelper/master/examples/v4.1/setting-dns.jpg "The tool can also restore the DNS values to automatic")

## Customizing DNS values 
The options offered by the tool are fully customizable through the `dns.json` file that comes with the release. The application offers menu items under its "Advanced" menu to directly edit and reload the dns.json file after editing.
![Editing](https://raw.githubusercontent.com/sverrirs/DnsHelper/master/examples/v4.1/editing-dnsfile.png "Editing the dns.json file")

