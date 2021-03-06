﻿=== License ===

Copyright (c) Lokad 2009 
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
    * Neither the name of Lokad nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

=== Lokad.Shared ===

This Open Source library contains common helper methods and routines that have proved themselves useful in different applications and projects. Partially inspiration and ideas come from the usage of:

    * Lokad.Common
    * Microsoft Enterprise Library Application Block
    * Composite Application Block
    * Microsoft Smart Client Software Factory
    * Autofac Inversion of Control Container
    * xLim

Lokad.Shared aims for efficient reuse and flexibility. It does not reference any 3rd party applications or libraries(only BCL). Instead, it provides some generic interfaces the could be used to decouple business logic from the cross-cutting concerns, while still leveraging specific functionality. Currently abstraction points are provided for:

    * Logging
    * Exception Handling
    * Reliability Layers
    * Monitoring and performance counters
    * IoC Container auto-registration routines

    
SVN repository is located at:
http://lokad.svn.sourceforge.net/svnroot/lokad/Platform/Trunk/Shared