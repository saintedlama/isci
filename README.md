# IsCI

Detect if builds or tests are running in a CI environment.

[![Travis Build Status](https://travis-ci.org/saintedlama/isci.svg?branch=master)](https://travis-ci.org/saintedlama/isci)
[![AppVeyor Build status](https://ci.appveyor.com/api/projects/status/yqd2ei5hp813wwcs?svg=true)](https://ci.appveyor.com/project/saintedlama/isci)

[![Coverage Status](https://coveralls.io/repos/github/saintedlama/isci/badge.svg?branch=master)](https://coveralls.io/github/saintedlama/isci?branch=master)

Inspired by the awesome node.js module ['ci-info'](https://github.com/watson/ci-info)

## Installation

```bash
dotnet add package IsCI
```

## Usage

```csharp
using IsCI;

var ci = DetectCI.IsCI();
// true if running in a ci environment

var vendor = DetectCI.GetCIVendor();
// get the vendor definition or null if not running in a ci environment

var isPr = DetectCI.IsPullRequest();
// true if a pull request build is detected
```

`DetectCI` is a static class to allow static usage for better readability

```csharp
using static IsCI.DetectCI;

var ci = IsCI();
var vendor = GetCIVendor();
var isPr = IsPullRequest();
```

## Supported CI Vendors

| Constant        | Name           | Support PR Detection  |
| --------------- |----------------| ---------------------:|
AppVeyor | APPVEYOR | ✅
AWS CodeBuild | CODEBUILD | 🚫
Bamboo | BAMBOO | 🚫
Bitbucket Pipelines | BITBUCKET | 🚫
Bitrise | BITRISE | ✅
Buddy | BUDDY | ✅
Buildkite | BUILDKITE | ✅
CircleCI | CIRCLE | ✅
Cirrus CI | CIRRUS | ✅
Codeship | CODESHIP | 🚫
Drone | DRONE | 🚫
dsari | DSARI | 🚫
GitLab CI | GITLAB | 🚫
GoCD | GOCD | 🚫
Hudson | HUDSON | 🚫
Jenkins | JENKINS | ✅
Magnum CI | MAGNUM | 🚫
Sail CI | SAIL | ✅
Semaphore | SEMAPHORE | ✅
Shippable | SHIPPABLE | ✅
Solano CI | SOLANO | ✅
Strider CD | STRIDER | 🚫
TaskCluster | TASKCLUSTER | 🚫
Team Foundation Server | TFS | 🚫
TeamCity | TEAMCITY | 🚫
Travis CI | TRAVIS | ✅
