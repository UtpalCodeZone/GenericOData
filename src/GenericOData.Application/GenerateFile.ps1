# Script 1: Generate code lines

$folderPath = "Models/V1/DataModels"
$builderFilePath = "Models/V1/EdmModel/GenerateEdmModel.cs"

# Get all .cs files in the Models folder
$csFiles = Get-ChildItem -Path $folderPath -Filter "*.cs" 

# Loop through each .cs file and generate the code line for each file
$codeLines = foreach ($csFile in $csFiles) {
    # Get the base file name
    $baseFileName = [System.IO.Path]::GetFileNameWithoutExtension($csFile)

    $entitySetName = $baseFileName
    # Concatenate the baseFileName with 's'
    if ($baseFileName -eq "o") {
        $entitySetName = $baseFileName + 's'
    }

    # Check if the code line already exists in the builder file
    $codeLine = "builder.EntitySet<DataModels.$baseFileName>(""$entitySetName"");"
    $existingContent = Get-Content -Path $builderFilePath -Raw
    $lineExists = $existingContent.Contains($codeLine)

    # Output the code line only if it doesn't exist
    if (-not $lineExists) {
        Write-Host "Inserting new code line: $codeLine"
        $codeLine
    }
}

# If no new code lines were generated, exit the script
if ($codeLines.Count -eq 0) {
    Write-Host "No new code lines to append."
    exit
}

# Join the code lines into a single string
$code = $codeLines -join "`r`n`t`t`t"

# Read the existing content of the builder file
$existingContent = Get-Content -Path $builderFilePath -Raw

# Find the line after which you want to append the code
$targetLine = $existingContent.IndexOf("ODataConventionModelBuilder builder = new();") + "ODataConventionModelBuilder builder = new();".Length

# Insert the generated code after the target line
$newContent = $existingContent.Insert($targetLine, "`r`n`t`t`t$code")

# Write the updated content back to the builder file
$newContent | Set-Content -Path $builderFilePath


# Script 2: Generate controller files

$templatePath = ".\Templates\GenerateControllerTemplate.txt"
$modelFolderPath = ".\Models\V1\DataModels"
$controllerFolderPath = "..\GenericOData.Api\Controllers\V1"

# Get the model file names
$modelFileNames = Get-ChildItem -Path $modelFolderPath -Filter "*.cs" | Select-Object -ExpandProperty Name

# Read the template content
$templateContent = Get-Content -Path $templatePath -Raw

# Iterate through each model file name
foreach ($modelName in $modelFileNames) {

    # Get the model name from the file name
    $newModelName = $modelName.Replace(".cs", "")

    # Set the controller name based on the model name
    $controllerName = $newModelName
    if ($newModelName -eq "o") {
        $controllerName += "s"
    }

    # Replace the placeholder with the model name in the template content
    $newContent = $templateContent.Replace("<#modelName#>", $newModelName).Replace("<#controllerName#>", $controllerName)    

    # Define the new controller file path
    $newFilePath = Join-Path -Path $controllerFolderPath -ChildPath ($controllerName.Replace(".cs", "") + "Controller.cs")

    # Check if the controller file already exists
    if (-not (Test-Path -Path $newFilePath)) {
        # Create the new controller file
        $newContent | Out-File -FilePath $newFilePath
        Write-Host "New controller file created: $newFilePath"
    } else {
        Write-Host "Controller file already exists: $newFilePath"
    }
}