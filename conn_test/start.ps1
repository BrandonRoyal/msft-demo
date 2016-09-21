ipconfig | Select-String 'Default Gateway' | ForEach-Object { $gateway = $_.Line.Substring(39) }
ping -t $gateway