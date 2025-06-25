# Get timestamp for output filename
$date = Get-Date -Format "yyyyMMdd_HHmmss"
$outputPath = "C:\TeamShare\NewNetworkConnections_$date.csv"

# Prepare a results array
$results = @()

# Get all TCP connections
$connections = Get-NetTCPConnection

foreach ($connection in $connections) {
    $processId = $connection.OwningProcess

    # Try to get the process by ID
    $process = Get-Process -Id $processId -ErrorAction SilentlyContinue
    $processName = $null
    $appPoolName = $null

    if ($process) {
        $processName = $process.ProcessName

        # If it's a w3wp.exe, get the App Pool Name
        if ($processName -eq 'w3wp') {
            $procInfo = Get-CimInstance -ClassName Win32_Process -Filter "ProcessId = $processId"
            if ($procInfo -and $procInfo.CommandLine -match '-ap\s+"([^"]+)"') {
                $appPoolName = $matches[1]
            }
        }
    }

    # Add to results
    $results += [PSCustomObject]@{
        LocalAddress   = $connection.LocalAddress
        LocalPort      = $connection.LocalPort
        RemoteAddress  = $connection.RemoteAddress
        RemotePort     = $connection.RemotePort
        State          = $connection.State
        OwningProcess  = $processId
        ProcessName    = $processName
        AppPoolName    = $appPoolName
    }
}

# Export the results to CSV
if ($results.Count -gt 0) {
    $results | Export-Csv -Path $outputPath -NoTypeInformation
    Write-Host "Exported network connection data to: $outputPath"
} else {
    Write-Host "No network connection data to export."
}
