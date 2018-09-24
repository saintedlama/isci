using System.Collections.Generic;
using System.Linq;
using IsCI.Vendors.PullRequests;

namespace IsCI.Vendors
{
    public static class VendorDefinitions
    {
        public static List<Vendor> Vendors { get; } = new List<Vendor>
        {
            new Vendor {
                Name = "AppVeyor",
                Constant = "APPVEYOR",
                DetectVendor =  new EnvironmentVariableIsDefined("APPVEYOR"),
                DetectPullRequest = new PullRequestEnvironmentVariableIsDefined("APPVEYOR_PULL_REQUEST_NUMBER")
            },
            new Vendor {
                Name = "Bamboo",
                Constant = "BAMBOO",
                DetectVendor =  new EnvironmentVariableIsDefined("bamboo_planKey")
            },
            new Vendor {
                Name = "Bitbucket Pipelines",
                Constant = "BITBUCKET",
                DetectVendor =  new EnvironmentVariableIsDefined("BITBUCKET_COMMIT")
            },
            new Vendor {
                Name =  "Bitrise",
                Constant = "BITRISE",
                DetectVendor = new EnvironmentVariableIsDefined("BITRISE_IO"),
                DetectPullRequest = new PullRequestEnvironmentVariableIsDefined("BITRISE_PULL_REQUEST")
            },
            new Vendor {
                Name = "Buddy",
                Constant = "BUDDY",
                DetectVendor = new EnvironmentVariableIsDefined("BUDDY_WORKSPACE_ID"),
                DetectPullRequest = new PullRequestEnvironmentVariableIsDefined("BUDDY_EXECUTION_PULL_REQUEST_ID")
            },
            new Vendor {
                Name = "Buildkite",
                Constant = "BUILDKITE",
                DetectVendor =  new EnvironmentVariableIsDefined("BUILDKITE"),
                DetectPullRequest = new PullRequestEnvironmentVariableNotDefinedWithValue("BUILDKITE_PULL_REQUEST", "false")
            },
            new Vendor {
                Name = "CircleCI",
                Constant = "CIRCLE",
                DetectVendor =  new EnvironmentVariableIsDefined("CIRCLECI"),
                DetectPullRequest = new PullRequestEnvironmentVariableIsDefined("CIRCLE_PULL_REQUEST")
            },
            new Vendor {
                Name = "Cirrus CI",
                Constant = "CIRRUS",
                DetectVendor =  new EnvironmentVariableIsDefined("CIRRUS_CI"),
                DetectPullRequest = new PullRequestEnvironmentVariableIsDefined("CIRRUS_PR")
            },
            new Vendor {
                Name = "AWS CodeBuild",
                Constant = "CODEBUILD",
                DetectVendor =  new EnvironmentVariableIsDefined("CODEBUILD_BUILD_ARN")
            },
            new Vendor {
                Name = "Codeship",
                Constant = "CODESHIP",
                DetectVendor = new EnvironmentVariableIsDefinedWithValue("CI_NAME", "codeship")
            },
            new Vendor {
                Name = "Drone",
                Constant = "DRONE",
                DetectVendor =  new EnvironmentVariableIsDefined("DRONE")
            },
            new Vendor {
                Name = "dsari",
                Constant = "DSARI",
                DetectVendor =  new EnvironmentVariableIsDefined("DSARI")
            },
            new Vendor {
                Name = "GitLab CI",
                Constant = "GITLAB",
                DetectVendor =  new EnvironmentVariableIsDefined("GITLAB_CI")
            },
            new Vendor {
                Name = "GoCD",
                Constant = "GOCD",
                DetectVendor =  new EnvironmentVariableIsDefined("GO_PIPELINE_LABEL")
            },
            new Vendor {
                Name = "Hudson",
                Constant = "HUDSON",
                DetectVendor =  new EnvironmentVariableIsDefined("HUDSON_URL")
            },
            new Vendor {
                Name = "Jenkins",
                Constant = "JENKINS",
                DetectVendor = new EnvironmentVariableIsDefined("JENKINS_URL", "BUILD_ID"),
                DetectPullRequest = new PullRequestEnvironmentVariableIsDefined("ghprbPullId", "CHANGE_ID")
            },
            new Vendor {
                Name = "Magnum CI",
                Constant = "MAGNUM",
                DetectVendor =  new EnvironmentVariableIsDefined("MAGNUM")
            },
            new Vendor {
                Name = "Sail CI",
                Constant = "SAIL",
                DetectVendor =  new EnvironmentVariableIsDefined("SAILCI"),
                DetectPullRequest = new PullRequestEnvironmentVariableIsDefined("SAIL_PULL_REQUEST_NUMBER")
            },
            new Vendor {
                Name = "Semaphore",
                Constant = "SEMAPHORE",
                DetectVendor =  new EnvironmentVariableIsDefined("SEMAPHORE"),
                DetectPullRequest = new PullRequestEnvironmentVariableIsDefined("PULL_REQUEST_NUMBER")
            },
            new Vendor {
                Name = "Shippable",
                Constant = "SHIPPABLE",
                DetectVendor =  new EnvironmentVariableIsDefined("SHIPPABLE"),
                DetectPullRequest = new PullRequestEnvironmentVariableHasValue("IS_PULL_REQUEST", "true")
            },
            new Vendor {
                Name = "Solano CI",
                Constant = "SOLANO",
                DetectVendor =  new EnvironmentVariableIsDefined("TDDIUM"),
                DetectPullRequest = new PullRequestEnvironmentVariableIsDefined("TDDIUM_PR_ID")
            },
            new Vendor {
                Name = "Strider CD",
                Constant = "STRIDER",
                DetectVendor =  new EnvironmentVariableIsDefined("STRIDER")
            },
            new Vendor {
                Name = "TaskCluster",
                Constant = "TASKCLUSTER",
                DetectVendor = new EnvironmentVariableIsDefined("TASK_ID", "RUN_ID")
            },
            new Vendor {
                Name = "TeamCity",
                Constant = "TEAMCITY",
                DetectVendor =  new EnvironmentVariableIsDefined("TEAMCITY_VERSION")
            },
            new Vendor {
                Name = "Team Foundation Server",
                Constant = "TFS",
                DetectVendor =  new EnvironmentVariableIsDefined("TF_BUILD")
            },
            new Vendor {
                Name = "Travis CI",
                Constant = "TRAVIS",
                DetectVendor =  new EnvironmentVariableIsDefined("TRAVIS"),
                DetectPullRequest = new PullRequestEnvironmentVariableNotDefinedWithValue("TRAVIS_PULL_REQUEST", "false")
            }
        };
    }
}
