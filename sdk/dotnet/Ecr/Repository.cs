// *** WARNING: this file was generated by pulumi-gen-awsx. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Awsx.Ecr
{
    /// <summary>
    /// A [Repository] represents an [aws.ecr.Repository] along with an associated [LifecyclePolicy] controlling how images are retained in the repo.
    /// 
    /// Docker images can be built and pushed to the repo using the [buildAndPushImage] method.  This will call into the `@pulumi/docker/buildAndPushImage` function using this repo as the appropriate destination registry.
    /// </summary>
    [AwsxResourceType("awsx:ecr:Repository")]
    public partial class Repository : Pulumi.ComponentResource
    {
        /// <summary>
        /// Underlying repository lifecycle policy
        /// </summary>
        [Output("lifecyclePolicy")]
        public Output<Pulumi.Aws.Ecr.LifecyclePolicy?> LifecyclePolicy { get; private set; } = null!;

        /// <summary>
        /// Underlying Repository resource
        /// </summary>
        [Output("repository")]
        public Output<Pulumi.Aws.Ecr.Repository> AwsRepository { get; private set; } = null!;


        /// <summary>
        /// Create a Repository resource with the given unique name, arguments, and options.
        /// </summary>
        ///
        /// <param name="name">The unique name of the resource</param>
        /// <param name="args">The arguments used to populate this resource's properties</param>
        /// <param name="options">A bag of options that control this resource's behavior</param>
        public Repository(string name, RepositoryArgs? args = null, ComponentResourceOptions? options = null)
            : base("awsx:ecr:Repository", name, args ?? new RepositoryArgs(), MakeResourceOptions(options, ""), remote: true)
        {
        }

        private static ComponentResourceOptions MakeResourceOptions(ComponentResourceOptions? options, Input<string>? id)
        {
            var defaultOptions = new ComponentResourceOptions
            {
                Version = Utilities.Version,
            };
            var merged = ComponentResourceOptions.Merge(defaultOptions, options);
            // Override the ID if one was specified for consistency with other language SDKs.
            merged.Id = id ?? merged.Id;
            return merged;
        }

        /// <summary>
        /// Build and push a docker image to ECR
        /// </summary>
        public Pulumi.Output<string> BuildAndPushImage(RepositoryBuildAndPushImageArgs? args = null)
            => Pulumi.Deployment.Instance.Call<RepositoryBuildAndPushImageResult>("awsx:ecr:Repository/buildAndPushImage", args ?? new RepositoryBuildAndPushImageArgs(), this).Apply(v => v.Image);
    }

    public sealed class RepositoryArgs : Pulumi.ResourceArgs
    {
        [Input("encryptionConfigurations")]
        private InputList<Pulumi.Aws.Ecr.Inputs.RepositoryEncryptionConfigurationArgs>? _encryptionConfigurations;

        /// <summary>
        /// Encryption configuration for the repository. See below for schema.
        /// </summary>
        public InputList<Pulumi.Aws.Ecr.Inputs.RepositoryEncryptionConfigurationArgs> EncryptionConfigurations
        {
            get => _encryptionConfigurations ?? (_encryptionConfigurations = new InputList<Pulumi.Aws.Ecr.Inputs.RepositoryEncryptionConfigurationArgs>());
            set => _encryptionConfigurations = value;
        }

        /// <summary>
        /// Configuration block that defines image scanning configuration for the repository. By default, image scanning must be manually triggered. See the [ECR User Guide](https://docs.aws.amazon.com/AmazonECR/latest/userguide/image-scanning.html) for more information about image scanning.
        /// </summary>
        [Input("imageScanningConfiguration")]
        public Input<Pulumi.Aws.Ecr.Inputs.RepositoryImageScanningConfigurationArgs>? ImageScanningConfiguration { get; set; }

        /// <summary>
        /// The tag mutability setting for the repository. Must be one of: `MUTABLE` or `IMMUTABLE`. Defaults to `MUTABLE`.
        /// </summary>
        [Input("imageTagMutability")]
        public Input<string>? ImageTagMutability { get; set; }

        /// <summary>
        /// A lifecycle policy consists of one or more rules that determine which images in a repository should be expired. If not provided, this will default to untagged images expiring after 1 day.
        /// </summary>
        [Input("lifecyclePolicy")]
        public Inputs.LifecyclePolicyArgs? LifecyclePolicy { get; set; }

        /// <summary>
        /// Name of the repository.
        /// </summary>
        [Input("name")]
        public Input<string>? Name { get; set; }

        [Input("tags")]
        private InputMap<string>? _tags;

        /// <summary>
        /// A map of tags to assign to the resource. If configured with a provider `default_tags` configuration block present, tags with matching keys will overwrite those defined at the provider-level.
        /// </summary>
        public InputMap<string> Tags
        {
            get => _tags ?? (_tags = new InputMap<string>());
            set => _tags = value;
        }

        public RepositoryArgs()
        {
        }
    }

    /// <summary>
    /// Arguments for building and publishing a docker image to ECR
    /// </summary>
    public sealed class RepositoryBuildAndPushImageArgs : Pulumi.CallArgs
    {
        [Input("args")]
        private InputMap<string>? _args;

        /// <summary>
        /// An optional map of named build-time argument variables to set during the Docker build.  This flag allows you to pass built-time variables that can be accessed like environment variables inside the `RUN` instruction.
        /// </summary>
        public InputMap<string> Args
        {
            get => _args ?? (_args = new InputMap<string>());
            set => _args = value;
        }

        [Input("cacheFrom")]
        private InputList<string>? _cacheFrom;

        /// <summary>
        /// Images to consider as cache sources
        /// </summary>
        public InputList<string> CacheFrom
        {
            get => _cacheFrom ?? (_cacheFrom = new InputList<string>());
            set => _cacheFrom = value;
        }

        /// <summary>
        /// dockerfile may be used to override the default Dockerfile name and/or location.  By default, it is assumed to be a file named Dockerfile in the root of the build context.
        /// </summary>
        [Input("dockerfile")]
        public Input<string>? Dockerfile { get; set; }

        [Input("env")]
        private InputMap<string>? _env;

        /// <summary>
        /// Environment variables to set on the invocation of `docker build`, for example to support `DOCKER_BUILDKIT=1 docker build`.
        /// </summary>
        public InputMap<string> Env
        {
            get => _env ?? (_env = new InputMap<string>());
            set => _env = value;
        }

        [Input("extraOptions")]
        private InputList<string>? _extraOptions;

        /// <summary>
        /// An optional catch-all list of arguments to provide extra CLI options to the docker build command.  For example `['--network', 'host']`.
        /// </summary>
        public InputList<string> ExtraOptions
        {
            get => _extraOptions ?? (_extraOptions = new InputList<string>());
            set => _extraOptions = value;
        }

        /// <summary>
        /// Path to a directory to use for the Docker build context, usually the directory in which the Dockerfile resides (although dockerfile may be used to choose a custom location independent of this choice). If not specified, the context defaults to the current working directory; if a relative path is used, it is relative to the current working directory that Pulumi is evaluating.
        /// </summary>
        [Input("path")]
        public Input<string>? Path { get; set; }

        /// <summary>
        /// The target of the dockerfile to build
        /// </summary>
        [Input("target")]
        public Input<string>? Target { get; set; }

        public RepositoryBuildAndPushImageArgs()
        {
        }
    }

    /// <summary>
    /// Arguments for building and publishing a docker image to ECR
    /// </summary>
    [OutputType]
    internal sealed class RepositoryBuildAndPushImageResult
    {
        /// <summary>
        /// Unique identifier of the pushed image
        /// </summary>
        public readonly string Image;

        [OutputConstructor]
        private RepositoryBuildAndPushImageResult(string image)
        {
            Image = image;
        }
    }
}
