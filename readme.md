# WASM + WASI Demo

This project contains the demo code belonging to my talk "Why Wasm is the perfect runtime for server-side applications."

## Hello world
The hello world is what is says... Just a simple hello world in C# that can be compiles to a webassembly file which you can almost everywhere.

To run it on your pc install [wasmtime](https://docs.wasmtime.dev/cli-install.html) and use the command
```wasmtime demo.wasm```

To give it access to the filesystem use
```wasmtime --dir=. demo.wasm```

## Spin
The second demo uses [Fermyon Spin](https://www.fermyon.com/spin) to run serverless (web) applications. The C# code example creates a simple web application
If you download Spin and put the .exe in the root of the Spin folder you can run it with the command ```spin up```

## Kubernetes
The last demo (k8s) uses Kubernetes to run a webassembly container (of only 6Mb size) to run a simple webapplication. This demo uses the Spin runtime so serve the webapplication!

For my demo I created a AKS cluster in Azure and used an Azure Container Registry for my container.

Be aware that this is still in preview...

To run wasm containers on AKS you need to add a WasmNodePool:
```
az feature register \
    --namespace Microsoft.ContainerService \
    --name WasmNodePoolPreview
```
Once it's completed, the resource provider for AKS must be refreshed to pick it up.
```
az provider register --namespace Microsoft.ContainerService
```
You need to create a Wasm/Wasi node pool and this must be done from the Azure CLI (not available in de Azure portal yet). So install this extension
```
az extension add --name aks-preview --upgrade
```
After creating your AKS cluster you can create your extra WASM/WASI Node pool where your Wasm containers can run
Use the following command to add the nodepool
```
az aks nodepool add \
    -n ${WASI_NODE_POLL} \
    -g ${RESOURCE_GROUP} \
    -c 1 \
    --cluster-name ${AKS_CLUSTER} \
    --workload-runtime WasmWasi
```

In the yaml folder I have 3 files to create the necessary resources in Kubernetes.
First you have to install a RuntimeClass so the pod can run on the WASM/WASI node pool. The ```SpinRuntime.yml``` holds the configuration to create a **kubernetes.azure.com/wasmtime-spin-v1** RuntimeClass to run Spin applications.

The ```spin-in-k8s.yml``` file creates the pod.
And the ```service.yml``` file creates a service to access the pod.





