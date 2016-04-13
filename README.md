# DnsHelper
Utility application to quickly swap between DNS servers for services such as [http://www.unblock-us.com](http://www.unblock-us.com) and [https://unlocator.com/](https://unlocator.com/).

This utility is in no way affiliated with any of the companies providing the DNS services. It is a custom tool I made as I wanted a simple way to switch between different DNS values quickly.

![Demo](http://i.imgur.com/tDRqKYJ.gif "Animated demonstration of the tool")

# Download
A binary release can be downloaded from [Releases](https://github.com/sverrirs/DnsHelper/releases). 
It is a single unsigned executable that requires administrator privileges to run, don't forget to also download the accompanying dns.json file.
Elevated privileges are necessary to be able to set the DNS values and restart the Network Adapter.

## Fast DNS configuration
With the recent arms race between VPN/DNS suppliers and Netflix. The DNS server addresses are likely to start changing very rapidly. 
This tool helps with applying new DNS values and restarting network adapters on Windows with only a few clicks.

## Can set any DNS values
The tool will apply any DNS IP values you type into it and will restart the network adaptor to make sure that the new values are read and applied correctly
![Applied](http://i.imgur.com/74E2xny.jpg "A IPv4 sheet showing values that the tool updated")

## Resetting to automatic
The tool can also quickly restore your DNS settings to "automatic"
![Auto](http://i.imgur.com/maNnu08.jpg "The tool can also restore the DNS values to automatic")


