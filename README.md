# EmotionApp

**Enterprise-Grade Local Sentiment Analysis & Emotion Classification**

[![Framework](https://img.shields.io/badge/.NET-8.0-512BD4?logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![Interface](https://img.shields.io/badge/UI-Windows%20Forms-0078D4?logo=windows&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
[![AI Engine](https://img.shields.io/badge/ML.NET-Native%20Inference-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/en-us/apps/machinelearning-ai/ml-dotnet)
[![Containerization](https://img.shields.io/badge/Docker-Supported-2496ED?logo=docker&logoColor=white)](https://www.docker.com/)
[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](LICENSE.txt)

---

## 📌 Executive Overview

**EmotionApp** is a high-performance, privacy-focused C# application designed to evaluate raw text strings and categorize them into specific human emotional spectrums. By strictly utilizing **ML.NET**, the application bypasses the need for external cloud APIs, making it ideal for secure environments requiring zero data leakage. 

The software features a smart "Environment Divergence" engine. It natively boots into a clean, intuitive Windows Forms GUI on desktop platforms, but automatically stabilizes into a headless, memory-mapped console iterator when executed inside isolated Linux Docker containers.

### Core Capabilities
- **Local Neural Processing:** Eliminates API latency and public cloud costs by performing full lifecycle training and inference locally.
- **Dynamic Multiclass Targeting:** Maps input text across 6 highly granular emotional classifications: *Joy, Sadness, Anger, Fear, Love,* and *Surprise*.
- **Headless Fault Tolerance:** Native protection against GDI+ thread initialization crashes in virtualized server environments.

---

## ⚙️ Technical Architecture & Pipeline

EmotionApp executes continuous text classification by passing string inputs through a strictly mapped vectorized training pipeline.

### The Algorithm: SDCA Maximum Entropy
For the core predictive engine, this project utilizes the **Stochastic Dual Coordinate Ascent (SDCA) Maximum Entropy** trainer. 
- **Multinomial Logistic Regression:** Unlike binary regressions that only solve for "Positive" vs. "Negative", MaxEnt naturally scales across multiple classes by executing Softmax probability distribution arrays.
- **N-Gram Vectorization:** Raw human sentences are broken down and assigned distinct mathematical weights based on localized features.
- **Resource Optimization:** The SDCA mathematical solver computes training duals rapidly, ensuring that enterprise-level datasets can be processed on consumer hardware without GPU dependencies.

---

## 🚀 Key Features

| Capability | Technical Specification |
|:---|:---|
| **Edge-Based Inference** | Zero network calls. High predictability metrics are handled 100% on localhost. |
| **Environmental Fallbacks** | Detects container runtime variables and abstracts WinForms threads into terminal lines. |
| **Dataset Sanitizer** | An automated pre-processor that ignores standard grammatical commas while maintaining strict semicolon (`;`) CSV column indices. |
| **Pipeline Serializer** | Compiles custom-trained weights and node architectures into a lightweight, portable `.zip` asset. |

---

## 🛠️ Technology Stack

| Tier | Component | Specification / Version |
|:---|:---|:---|
| **Core Runtime** | .NET | 8.0 (LTS) |
| **Primary Language** | C# | 12.0 |
| **Machine Learning** | Microsoft.ML | 4.0.1+ |
| **Desktop UI** | Windows Forms | Framework Native |
| **Virtualization** | Docker Engine | Multi-Stage Builds |

---

## 📥 Installation & Deployment

### System Prerequisites
- **Local Desktop Execution:** Windows 10 / 11 (X64) & .NET 8.0 SDK.
- **Development IDE:** Visual Studio 2022 (with Desktop Development workloads).
- **Server Execution:** Docker Desktop / Docker CE (Linux containers enabled).

### Method 1: CLI Compilation
To build and execute the application binaries manually via the command line:
```bash
# 1. Clone the remote repository
git clone https://github.com/Saree-tech/EmotionApp.git

# 2. Navigate into the project folder
cd EmotionApp

# 3. Restore dependencies and compile
dotnet restore
dotnet build --configuration Release

# 4. Execute the application
dotnet run
````

### Method 2: Enterprise IDE (Visual Studio 2022)

1.  Open the source directory and double-click the `EmotionApp.sln` solution asset.
2.  Allow Visual Studio to auto-resolve NuGet package binaries.
3.  Build the solution using the native hotkey sequence (`Ctrl + Shift + B`).
4.  Press `F5` or click "Start" to execute the debugger.

-----

## 🐳 Docker Containerization

The application includes a targeted `EmotionApp.Docker.csproj` and a multi-stage `Dockerfile`. This ensures that the published asset only carries minimal runtime packages instead of heavy visual SDKs.

### Deployment Instructions

To build and run the application in an isolated state:

```bash
# 1. Purge legacy containers if necessary
docker rm my_emotion_container

# 2. Compile the Docker image (Multi-stage)
docker build -t emotion-app-image .

# 3. Initialize headless console execution
docker run --name my_emotion_container emotion-app-image
```

-----

## 📊 Visual Previews & Screenshots

### Standard Native GUI (Client View)

The localized desktop interface where users provide text block payloads.

### Model Probability Output

Active text classification running post-inference calculation.

### Virtualized Runtime

The application running smoothly in a headless Linux environment.

-----

## 📄 Licensing & Open Source

This project is released and licensed under the **Apache License, Version 2.0**. For permissions regarding modification, enterprise distribution, and private use, please consult the standard license text.

-----

## ✉️ Contact & Support

**Sareen Fatima**

  - **GitHub Portal:** [github.com/Saree-tech](https://github.com/Saree-tech)
  - **Source Repository:** [EmotionApp](https://github.com/Saree-tech/EmotionApp)

-----

*Maintained and optimized with .NET 8.0 and ML.NET*

```
```
