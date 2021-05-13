#To use this file, say:
# . make.ps1
# then, say make_clean or make_build
$tf = 'net4.7.1'
#$unityassets = 'client/EschatonUnity/Assets/'
$unityassets = 'RunespiritUnity/Assets/'
$unitydlls = 'C:/Program Files/Unity/Hub/Editor/2020.2.1f1/Editor/Data/Managed'
$sln = 'Runespirit.sln'

function make_clean
{
    dotnet clean $sln -p:"TargetFramework=$tf;UnityAssets=$unityassets;DLLPath=$unitydlls"
}
function make_build
{
    dotnet build $sln -p:"TargetFramework=$tf;UnityAssets=$unityassets;DLLPath=$unitydlls"
}

###
#
#
# dotnet build GGJ2021.sln -p:"TargetFramework=net4.7.1;UnityAssets=KeeperUnity/Assets;DLLPath=C:/Program Files/Unity/Hub/Editor/2020.2.1f1/Editor/Data/Managed"
#
# Clean
# dotnet clean GGJ2021.sln -p:"TargetFramework=net4.7.1;UnityAssets=KeeperUnity/Assets;DLLPath=C:/Program Files/Unity/Hub/Editor/2020.2.1f1/Editor/Data/Managed"