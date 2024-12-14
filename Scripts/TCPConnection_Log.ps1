$date = Get-Date -Format "yyyyMMdd_HHmmss"

Get-NetTCPConnection |
Select-Object LocalAddress, LocalPort, RemoteAddress, RemotePort, State, OwningProcess, @{Name='ProcessName';Expression={(Get-Process -Id $_.OwningProcess -ErrorAction SilentlyContinue).ProcessName}} |
	Export-Csv -Path "C:\Temp\NetworkConnections_$date.csv" -NoTypeInformation

