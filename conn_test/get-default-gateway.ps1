[cmdletbinding()]
param (
 [parameter(ValueFromPipeline=$true,ValueFromPipelineByPropertyName=$true)]
    [string[]]$ComputerName = $env:computername
)

begin {}
process {
 foreach ($Computer in $ComputerName) {
  if(Test-Connection -ComputerName $Computer -Count 1 -ea 0) {
   try {
    $Networks = Get-WmiObject Win32_NetworkAdapterConfiguration -ComputerName $Computer -EA Stop | ? {$_.IPEnabled}            
   } catch {
        Write-Warning "Error occurred while querying $computer." 
        Continue 
   }
   foreach ($Network in $Networks) {
    $Network.DefaultIPGateway                   
   }
  }
 }
}
            
end {}