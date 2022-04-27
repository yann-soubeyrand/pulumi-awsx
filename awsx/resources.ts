// Copyright 2016-2022, Pulumi Corporation.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

import * as pulumi from "@pulumi/pulumi";
import { Trail } from "./cloudtrail";
import { Repository } from "./ecr";
import { Repository_buildAndPushImage } from "./ecr/buildAndPushImage";
import {
    EC2Service,
    EC2TaskDefinition,
    FargateService,
    FargateTaskDefinition,
} from "./ecs";
import { ApplicationLoadBalancer } from "./lb";
import {
    ConstructComponent,
    Functions,
    ResourceConstructor,
} from "./schema-types";
import { Vpc } from "./vpc";

const resources: ResourceConstructor = {
    "awsx:cloudtrail:Trail": (...args) => new Trail(...args),
    "awsx:ecs:FargateService": (...args) => new FargateService(...args),
    "awsx:ecs:EC2Service": (...args) => new EC2Service(...args),
    "awsx:ecs:EC2TaskDefinition": (...args) => new EC2TaskDefinition(...args),
    "awsx:ecs:FargateTaskDefinition": (...args) =>
        new FargateTaskDefinition(...args),
    "awsx:lb:ApplicationLoadBalancer": (...args) =>
        new ApplicationLoadBalancer(...args),
    "awsx:vpc:Vpc": (...args) => new Vpc(...args),
    "awsx:ecr:Repository": (...args) => new Repository(...args),
};

export function construct(
    name: string,
    type: string,
    inputs: pulumi.Inputs,
    options: pulumi.ComponentResourceOptions,
) {
    const genericResources: Record<string, ConstructComponent> = resources;
    const resource = genericResources[type];
    if (resource === undefined) {
        return undefined;
    }
    return resource(name, inputs, options);
}

export const functions: Functions = {
    "awsx:ecr:Repository/buildAndPushImage": Repository_buildAndPushImage,
};
