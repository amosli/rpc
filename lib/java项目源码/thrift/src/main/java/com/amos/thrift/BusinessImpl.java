package com.amos.thrift;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import org.apache.thrift.TException;

public class BusinessImpl implements ThriftCase.Iface {

	public int testCase1(int num1, int num2, String num3) throws TException {
		System.out.println("case1......");
		int result = num1 + num2;
		System.out.println("num1+num2:" + result + "  num3:" + num3);

		return result;
	}

	public List<String> testCase2(Map<String, String> num1) throws TException {
		System.out.println("case2......");
		List<String> list = new ArrayList<String>();
		Iterator<Entry<String, String>> items = num1.entrySet().iterator();

		while (items.hasNext()) {
			System.out.println(items.next().getKey() + ":"
					+ items.next().getValue());
			list.add(items.next().getKey() + ":" + items.next().getValue());
		}

		return list;
	}

	public void testCase3() throws TException {
		System.out.println("case3......");
		System.out.println("nothing is here!");
	}

	public void testCase4(List<Blog> blog) throws TException {

		System.out.println("case4......");
		for (Blog bl : blog) {
			System.out.println("id:" + bl.id);
			System.out.println("content:" + bl.content);
			System.out.println("ipAddress:" + bl.ipAddress);
			System.out.println("topic:" + bl.topic);
			System.out.println("topic:" + bl.props);
		}
	}

}
