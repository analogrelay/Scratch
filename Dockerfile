FROM ubuntu:14.04

ENV DNX_VERSION 1.0.0-beta8
ENV DNX_USER_HOME /opt/dnx
ENV DNX_FEED https://www.myget.org/F/aspnetvolatilerelease/api/v2

RUN apt-get -qq update && apt-get -qqy install unzip curl libunwind8 gettext libssl-dev libcurl3-dev zlib1g libicu-dev libcurl3-gnutls

RUN curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_USER_HOME=$DNX_USER_HOME DNX_BRANCH=release sh
RUN bash -c "source $DNX_USER_HOME/dnvm/dnvm.sh && dnvm install 1.0.0-beta8-15849 -r coreclr -alias default && dnvm alias default | xargs -i ln -s $DNX_USER_HOME/runtimes/{} $DNX_USER_HOME/runtimes/default"

ENV PATH $PATH:$DNX_USER_HOME/runtimes/default/bin
