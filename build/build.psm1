$PSScriptRoot | Join-Path -ChildPath *.ps1 | Resolve-Path | ForEach-Object -Process  { . $_ }
Export-ModuleMember -Function *