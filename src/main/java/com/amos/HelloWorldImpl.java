package com.amos;

/**
 * Created by amosli on 14-8-12.
 */
public class HelloWorldImpl implements HelloWorldService.Iface {

    public HelloWorldImpl() {
    }

    @Override
    public String sayHello(String username) {
        return "Hi," + username + " ,Welcome to the thrift's world !";
    }

}