#addin nuget:?package=Cake.Docker&version=1.2.3

var target = Argument("target", "SystemTest");

Task("SystemTest")
    .Does(() =>
{
    DockerComposeUp(new DockerComposeUpSettings
    {
        Files = new string[] { "docker-compose.systest.yml" },
        Build = true,
        ExitCodeFrom = "systest",
        AbortOnContainerExit = true
    });
});

RunTarget(target);
