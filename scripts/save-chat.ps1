param(
    [Parameter(Mandatory=$true)]
    [string]$SourcePath,

    [string]$TargetDir = 'files/chats'
)

# Ensure target dir exists
$root = (Get-Location).Path
$fullTarget = Join-Path $root $TargetDir
New-Item -ItemType Directory -Force -Path $fullTarget | Out-Null

# Create timestamped filename
$timestamp = Get-Date -Format 'yyyy-MM-ddTHH-mm-ss'
$baseName = [System.IO.Path]::GetFileNameWithoutExtension($SourcePath)
$ext = [System.IO.Path]::GetExtension($SourcePath)
$dst = Join-Path $fullTarget ("$timestamp-$baseName$ext")

# Copy content
Copy-Item -Path $SourcePath -Destination $dst -Force
Write-Host "Saved chat export to: $dst"
